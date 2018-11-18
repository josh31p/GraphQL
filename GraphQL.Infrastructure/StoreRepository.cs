
using System.Collections.Generic;
using System.Linq;
using GraphQL.Core.Data;
using GraphQL.Core.Models;

namespace GraphQL.Infrastructure
{
    public class StoreRepository : IStoreRepository
    {
        private readonly List<Store> _stores = new List<Store>();

        public StoreRepository()
        {
            PopulateStores();
        }
        
        public List<Store> GetAllStores()
        {
            return _stores;
        }

        public Store GetStoreById(int id)
        {
            return _stores.FirstOrDefault(s => s.StoreId == id);
        }

        private void PopulateStores()
        {
            _stores.Add(new Store(1,"Luton","09:00","5:00"));
            _stores.Add(new Store(2, "Bedford", "09:00", "5:30"));
            _stores.Add(new Store(3, "MK", "10:00", "5:00"));
        }
    }
}
