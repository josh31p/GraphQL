
using GraphQL.Core.Models;
using GraphQL.Types;

namespace GraphQL.API.Types
{
    public class StoreType : ObjectGraphType<Store>
    {
        public StoreType()
        {
            Name = "Store";
            Field(x => x.StoreId).Description("The store ID.");
            Field(x => x.StoreName).Description("The store name.");
            Field(x => x.ClosingTime).Description("The store closing time.");
            Field(x => x.OpeningTime).Description("The store opening time.");
        }
    }
}
