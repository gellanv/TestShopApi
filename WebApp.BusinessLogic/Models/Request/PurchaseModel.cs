namespace WebApp.BusinessLogic.Models.Request
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
        public ICollection<PurchaseProductModel> PurchaseProducts { get; set; }
    }
}
