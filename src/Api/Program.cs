using Application.Users;
using Infrastructure.Users;
using Infrastructure.Common;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();

services.RegisterInfrastructureDependencies();
services.RegisterUserDependencies();
services.RegisterUserHandlers();

services.AddMassTransit(x =>
{
    x.UsingRabbitMq();
});


services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }
