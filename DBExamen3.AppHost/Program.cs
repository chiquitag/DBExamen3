var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DBExamen3>("dbexamen3");

builder.Build().Run();
