using GraphQL.Types;

namespace GraphQL.WebApi.GraphQL
{
    public class MovieReviewSchema : Schema
    {
        public MovieReviewSchema(QueryObject query, MutationObject mutation, IServiceProvider sp) : base(sp)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
