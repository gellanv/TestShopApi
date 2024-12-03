namespace WebApp.DataAccess.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
    }
}
