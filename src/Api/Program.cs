using Application.Users;
using Infrastructure.Users;
using Infrastructure.Common;
using MassTransit;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.AuthorizationTokens;

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

services.AddSwaggerGen(c =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // must be lower case
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                securityScheme, Array.Empty<string>()
            }
        });
});

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = AuthOptions.CreateValidationParameters();
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }
