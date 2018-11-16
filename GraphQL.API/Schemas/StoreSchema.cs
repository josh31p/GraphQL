using System;
using GraphQL.API.Queries;
using GraphQL.Types;

namespace GraphQL.API.Schemas
{
    public class StoreSchema : Schema
    {

        public StoreSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (StoreQuery)resolveType(typeof(StoreQuery));
        }
    }
}
