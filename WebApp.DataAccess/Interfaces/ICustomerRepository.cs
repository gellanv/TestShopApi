using WebApp.DataAccess.Entities;

namespace WebApp.DataAccess.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IEnumerable<Customer>> GetBirthdayCustomers(DateTime date);
}
