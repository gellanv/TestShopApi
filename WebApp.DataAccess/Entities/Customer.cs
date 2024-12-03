namespace WebApp.DataAccess.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}
