using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQL.WebApi.Data.Repositories;
using GraphQL.WebApi.GraphQL.Types;
using GraphQL.WebApi.Models;
using System.Xml.Linq;

namespace GraphQL.WebApi.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IMovieRepository repository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";

            AddField(new FieldType
            {
                Name = "addReview",
                Description = "Add review to a movie.",
                Type = typeof(MovieObject),
                Arguments = new QueryArguments
                (
                    new QueryArgument<NonNullGraphType<GuidGraphType>>
                    {
                        Name = "id",
                        Description = "The unique GUID of the movie."
                    },
                    new QueryArgument<NonNullGraphType<ReviewInputObject>>
                    {
                        Name = "review",
                        Description = "Review for the movie"
                    }
                ),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var review = context.GetArgument<Review>("review");
                    return repository.AddReviewToMovieAsync(id, review);
                })
            });
        }
    }
}
