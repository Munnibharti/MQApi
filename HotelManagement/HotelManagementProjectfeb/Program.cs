using FluentValidation.AspNetCore;
using HotelManagementProjectfeb.Data;
using HotelManagementProjectfeb.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//DTO  full form data transfer eobject

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//for fluent validation dome by uma
builder.Services.AddFluentValidation(option => option.RegisterValidatorsFromAssemblyContaining<Program>());


builder.Services.AddDbContext<HotelManagementDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

//This is necessary for navigation proprerty
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



builder.Services.AddScoped<IGuestRepository, GuestRepository>();

builder.Services.AddScoped<IBillRepository, BillRepository>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<IReceptionistRepositories, ReceptionistRepository>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddScoped<IInventoryRepositorycs, InventoryRepository>();

builder.Services.AddScoped<IManagerRepository, ManagerRepository>();

builder.Services.AddSingleton<IUserRepository, StaticUserRepository>();

builder.Services.AddScoped<ITokenHandler, HotelManagementProjectfeb.Repositories.TokenHandler>();
//here dependency injection

//here automapper

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
       
}

app.UseHttpsRedirection();
//its means allowing api to talk to 

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
