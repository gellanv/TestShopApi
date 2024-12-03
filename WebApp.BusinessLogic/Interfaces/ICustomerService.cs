using WebApp.BusinessLogic.Models.Request;
using WebApp.BusinessLogic.Models.Response;
using WebApp.DataAccess.Entities;

namespace WebApp.BusinessLogic.Interfaces;

public interface ICustomerService : ICrud<CustomerModel>
{
    Task<IEnumerable<BirthdayCustomer>> GetBirthdayCustomersAsync(DateTime date);
}
