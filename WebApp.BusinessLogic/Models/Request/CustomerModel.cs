namespace WebApp.BusinessLogic.Models.Request
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<PurchaseModel> Purchases { get; set; }
    }
}
