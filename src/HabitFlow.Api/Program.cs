var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthorization();

builder.Services.AddAuthentication()
    .AddKeycloakJwtBearer("keycloak", realm: "habitflow", options =>
    {
        options.RequireHttpsMetadata = false;
        options.Audience = "account";
    });


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


app.MapGet("/", () =>
{
    return "Nothing yet.";
})
.WithName("Root")
.WithOpenApi()
.RequireAuthorization();

app.Run();