using WebApp.BusinessLogic.Models.Request;
using WebApp.BusinessLogic.Models.Response;
using WebApp.DataAccess.Entities;

namespace WebApp.BusinessLogic.Interfaces;

public interface ICategoryService : ICrud<CategoryModel>
{
    Task<IEnumerable<PopularCategory>> GetCategoriesByCustomerAsync(int customerId);
}
