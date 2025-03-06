using HabitFlow.Infrastructure;
using HabitFlow.Application;
using Microsoft.Data.SqlClient;
using HabitFlow.Api.Users;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddAspireInfrastructureOrchestration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapUserEndpoints();

//app.MapGet("/", (SqlConnection sql) =>
//{
//    return "Nothing yet.";
//})
//.WithName("Root")
//.WithOpenApi()
//.RequireAuthorization();

app.Run();