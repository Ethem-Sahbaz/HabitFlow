var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HabitFlow_Api>("habitflow-api");

builder.Build().Run();
