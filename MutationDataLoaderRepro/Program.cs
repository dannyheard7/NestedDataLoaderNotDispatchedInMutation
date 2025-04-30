using MutationDataLoaderRepro;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddMutationDataLoaderReproTypes();

var app = builder.Build();

app.MapGraphQL();

app.Run();