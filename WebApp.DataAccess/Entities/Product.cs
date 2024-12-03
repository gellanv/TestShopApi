namespace WebApp.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PurchaseProduct> PurchaseItems { get; set; }
    }
}
