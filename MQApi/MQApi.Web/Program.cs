using Microsoft.EntityFrameworkCore;
using MQApi.Web.Data;
using MQApi.Web.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
