using WebApp.DataAccess.Entities;

namespace WebApp.DataAccess.Interfaces;

public interface IPurchaseRepository : IRepository<Purchase>
{
    Task<IEnumerable<Purchase>> GetRecentPurphaseAsync(int days);
    Task<IEnumerable<Purchase>> GetPurchaseByCustomerAsync(int customerId);
}
