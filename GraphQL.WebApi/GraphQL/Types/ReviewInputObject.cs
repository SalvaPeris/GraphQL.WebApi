﻿using GraphQL.Types;
using GraphQL.WebApi.Models;

namespace GraphQL.WebApi.GraphQL.Types
{
    public sealed class ReviewInputObject : InputObjectGraphType<Review>
    {
        public ReviewInputObject()
        {
            Name = "ReviewInput";
            Description = "A review of the movie";

            Field(r => r.Reviewer)
                .Description("Name of the reviewer");

            Field(r => r.Stars)
                .Description("Star rating out of five");
        }
    }
}
