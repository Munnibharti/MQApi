using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MQApi.Web.Data;
using MQApi.Web.Repositories;
using System.Runtime.CompilerServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//this is for api authorization inside sagger 

builder.Services.AddSwaggerGen(options =>
{
	var securityScheme = new OpenApiSecurityScheme
	{
		Name = "JWT Authentication",
		Description = "Enter a valid JWT bearer token",
		In = ParameterLocation.Header,
		Scheme = "bearer",
		BearerFormat = "JWT",
		Reference = new OpenApiReference
		{
			Id = JwtBearerDefaults.AuthenticationScheme,
			Type = ReferenceType.SecurityScheme
		}

	};
    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] {} }
    });
});




//This is for Api fluent validation
builder.Services.
	AddFluentValidation(option => option.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddDbContext<WebApiWalksDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("MQApi"));
}
);

//This is necessary for navigation proprerty
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalkRepositroy, WalkRepository> ();
builder.Services.AddScoped<_IWalkDifficultyRepository, WalkDifficultyRepo>();

//then only one instace of static repository will be created
builder.Services.AddSingleton<IUserRepository, StaticUserRepository>();
//For Jwt 
builder.Services.AddScoped<ITokenHandler, MQApi.Web.Repositories.TokenHandler>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
//for jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience= true,	
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Audience"],
		IssuerSigningKey  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
//app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
