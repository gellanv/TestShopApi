namespace WebApp.BusinessLogic.Models.Request
{
    public class PurchaseProductModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int PurchaseId { get; set; }
        public PurchaseModel Purchase { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
