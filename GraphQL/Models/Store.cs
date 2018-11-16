
namespace GraphQL.Core.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }

        public Store(int storeId, string storeName, string openingTime, string closingTime)
        {
            StoreId = storeId;
            StoreName = storeName;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }
    }
}
