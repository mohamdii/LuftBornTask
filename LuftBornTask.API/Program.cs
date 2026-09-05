using LuftBornTask.API.Middleware;
using LuftBornTask.Application;
using LuftBornTask.Application.Behavior;
using LuftBornTask.Application.DIWiring;
using LuftBornTask.Infrastructure.DIWiring;
using LuftBornTask.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(ApplicationAssemblyMarker).Assembly
    ));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviors<,>));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAd");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseExceptionHandling();
app.UseCors("AllowAngularDev");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
