
using AutoMapper;
using GraphQL.API.Models;
using GraphQL.API.Types;
using GraphQL.Core.Data;
using GraphQL.Types;

namespace GraphQL.API.Queries
{

    public class StoreQuery : ObjectGraphType
    {

        public StoreQuery(IStoreRepository storeRepository, IMapper mapper)
        {
            Name = "Query";
            Field<StoreType>(
                "store",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id"}
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var store = storeRepository.GetStoreById(id);
                    var mapped = mapper.Map<Store>(store);
                    return mapped;
                }
            );
        }

    }
}
