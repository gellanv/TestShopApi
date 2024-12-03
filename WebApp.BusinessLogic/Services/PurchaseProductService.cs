using AutoMapper;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic.Models.Request;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.BusinessLogic.Services;

public class PurchaseProductService : IPurchaseProductService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper automapper;

    public PurchaseProductService(IUnitOfWork unitOfWork, IMapper automapper)
    {
        this.unitOfWork = unitOfWork;
        this.automapper = automapper;
    }

    public Task AddAsync(PurchaseProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(PurchaseProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PurchaseProductModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseProductModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PurchaseProductModel model)
    {
        throw new NotImplementedException();
    }
}
