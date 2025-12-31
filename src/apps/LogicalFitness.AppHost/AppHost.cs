var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
  .AddPostgres("pg-logical-fitness")
  .WithDataVolume("pg-logical-fitness-data");

var db = postgres.AddDatabase("db-logical-fitness");



builder.Build().Run();
