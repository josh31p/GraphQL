
using GraphQL.Core.Models;

namespace GraphQL.Core.Data
{
    public interface IStoreRepository
    {
        Store GetStoreById(int id);
    }
}
