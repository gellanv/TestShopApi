using AutoMapper;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic.Models.Request;
using WebApp.BusinessLogic.Models.Response;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.BusinessLogic.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper automapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper automapper)
    {
        this.unitOfWork = unitOfWork;
        this.automapper = automapper;
    }

    public async Task<IEnumerable<PopularCategory>> GetCategoriesByCustomerAsync(int customerId)
    {
        var purchases = await unitOfWork.PurchaseRepository.GetPurchaseByCustomerAsync(customerId);


        var categoriesWithQuantity = purchases
         .SelectMany(p => p.PurchaseProducts)
         .GroupBy(pp => pp.Product.Category)
         .Select(g => new PopularCategory
         {
             Id = g.Key.Id,
             CategoryName = g.Key.CategoryName,
             TotalQuantity = g.Sum(pp => pp.Quantity)
         })
         .ToList();

        return categoriesWithQuantity;
    }

    public Task AddAsync(CategoryModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(CategoryModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CategoryModel model)
    {
        throw new NotImplementedException();
    }
}
