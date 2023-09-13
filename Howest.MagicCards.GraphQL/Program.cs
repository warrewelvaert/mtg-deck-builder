using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.GraphQL.Schemas;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddDbContext<MtgV1Context>
    (options => options.UseSqlServer(config.GetConnectionString("CardsDB")));

builder.Services.AddScoped<ICardRepository, SqlCardRepository>();
builder.Services.AddScoped<IArtistRepository, SqlArtistRepository>();

builder.Services.AddScoped<RootSchema>();
builder.Services.AddGraphQL()
    .AddGraphTypes(typeof(RootSchema), ServiceLifetime.Scoped)
    .AddDataLoader()
    .AddSystemTextJson();

var app = builder.Build();

app.UseGraphQL<RootSchema>();
app.UseGraphQLPlayground(options: new PlaygroundOptions()
{
    EditorTheme = EditorTheme.Dark
});
app.Run();
