using AutoMapper;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic.Models.Request;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.BusinessLogic.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper automapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper automapper)
    {
        this.unitOfWork = unitOfWork;
        this.automapper = automapper;
    }

    public Task AddAsync(ProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(ProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProductModel model)
    {
        throw new NotImplementedException();
    }
}
