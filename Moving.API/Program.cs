using Moving.AI;
using Moving.API.Map;
using Moving.Application;
using Moving.Core;
using Moving.Infra.Context;
using Moving.Infra;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

Configuration.OpenAi.ApiKey =
    builder.Configuration.GetValue<string>("OpenAi:ApiKey") ??
    throw new Exception("Open ai API Key not found in configuration");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddItemServiceApplication();
builder.Services.AddServices();
builder.Services.AddAgents();
builder.Services.AddRepositories();
builder.Services.AddContexts(builder.Environment.ContentRootPath);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SqliteContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/{documentName}.json");
    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/openapi/{documentName}.json");
        options.AddDocument("v1");
    });

    // Optional: Automatically redirect root URL to the Scalar UI
    app.MapGet("/", () => Results.Redirect("/scalar"));
}

app.UseHttpsRedirection();

app.AddMap();

app.Run();
