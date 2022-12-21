using GraphQLServer.Data;
using GraphQLServer.GraphQL;
using GraphQLServer.MethodExtensions;
using Microsoft.EntityFrameworkCore;using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .RegisterDbContext<BlogContext>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();


builder.Services
        .AddDbContext<BlogContext>(options =>
                      options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnection"),
                      x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "blog")));

var app = builder.Build();

await app.ConfigurarMigraciones();

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
