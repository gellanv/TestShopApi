namespace WebApp.BusinessLogic.Models.Request
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public ICollection<PurchaseProductModel> PurchaseItems { get; set; }
    }
}
