using WebApp.BusinessLogic.Models.Request;
using WebApp.BusinessLogic.Models.Response;
using WebApp.DataAccess.Entities;

namespace WebApp.BusinessLogic.Interfaces;

public interface IPurchaseService : ICrud<PurchaseModel>
{
    Task<IEnumerable<RecentCustomerPurphase>> GetRecentPurphaseAsync(int days);
}
