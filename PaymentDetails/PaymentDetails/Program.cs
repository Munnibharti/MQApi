using Microsoft.EntityFrameworkCore;
using PaymentDetails.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

 builder.Services.AddDbContext<PaymentDetailContext>(options =>
 {
     options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
     });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
