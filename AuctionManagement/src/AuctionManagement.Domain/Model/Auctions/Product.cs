namespace AuctionManagement.Domain.Model.Auctions
{
    public class SellingProduct
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public SellingProduct(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
