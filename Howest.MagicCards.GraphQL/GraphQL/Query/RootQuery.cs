using GraphQL;
using GraphQL.Types;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.GraphQL.Types;
using Howest.MagicCards.DAL.Models;
using FluentValidation;

namespace Howest.MagicCards.GraphQL.GraphQL.Query
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(ICardRepository cardRepository, IArtistRepository artistRepository)
        {
            Field<ListGraphType<Types.CardType>>(
                "cards",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "power", Description = "Filter by power" },
                    new QueryArgument<IntGraphType> { Name = "toughness", Description = "Filter by toughness" },
                    new QueryArgument<IntGraphType> { Name = "limit", Description = "limit the amount of cards" }
                ),
                description: "Get all cards",
                resolve: context =>
                {
                    int? limit = context.GetArgument<int?>("limit");
                    int? power = context.GetArgument<int?>("power");
                    int? toughness = context.GetArgument<int?>("toughness");

                    IQueryable<Card> filteredCards = cardRepository.GetAllCards();

                    if (power.HasValue && limit.Value >= 0)
                    {
                        filteredCards = filteredCards.Where(card => card.Power == power.ToString());
                    }

                    if (toughness.HasValue && limit.Value >= 0)
                    {
                        filteredCards = filteredCards.Where(card => card.Toughness == toughness.ToString());
                    }

                    if (limit.HasValue && limit.Value > 0)
                    {
                        filteredCards = filteredCards.Take(limit.Value);
                    }

                    return filteredCards.ToList();
                }
            );

            Field<ListGraphType<ArtistType>>(
                "artists",
                Description = "Get all artists",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "limit", Description = "limit the amount of artists" }),
                resolve: context =>
                {
                    int? limit = context.GetArgument<int?>("limit");
                    IQueryable<Artist> allArtists = artistRepository.GetAllArtists();
                    if (limit.HasValue && limit.Value > 0)
                    {
                        allArtists = allArtists.Take(limit.Value);
                    }
                    return allArtists.ToList();
                }
            );

            Field<ArtistType>(
            "artist",
                Description = "Get an artist by id",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "id of the artist" }),
                resolve: context =>
                {
                    return artistRepository.GetArtistById(context.GetArgument<int>("id"));
                }
            );
        }
    }
}
