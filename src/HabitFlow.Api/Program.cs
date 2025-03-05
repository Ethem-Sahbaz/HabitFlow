using HabitFlow.Infrastructure;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddAspireInfrastructureOrchestration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


app.MapGet("/", (SqlConnection sql) =>
{
    return "Nothing yet.";
})
.WithName("Root")
.WithOpenApi()
.RequireAuthorization();

app.Run();