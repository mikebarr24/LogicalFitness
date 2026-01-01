using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
  .AddPostgres("pg-logical-fitness")
  .WithDataVolume("pg-logical-fitness-data")
  .WithHostPort(51571);

var db = postgres.AddDatabase("db-logical-fitness");

var apiService = builder.AddProject<LogicalFitness_Api>("apiservice")
  .WaitFor(db);

builder.Build().Run();
