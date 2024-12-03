using AutoMapper;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic.Models.Request;
using WebApp.BusinessLogic.Models.Response;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.BusinessLogic.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper automapper;

    public PurchaseService(IUnitOfWork unitOfWork, IMapper automapper)
    {
        this.unitOfWork = unitOfWork;
        this.automapper = automapper;
    }

    public async Task<IEnumerable<RecentCustomerPurphase>> GetRecentPurphaseAsync(int days)
    {
        var purchases = await unitOfWork.PurchaseRepository.GetRecentPurphaseAsync(days);

        var recentCustomers = purchases
        .GroupBy(p => p.Customer)
        .Select(g => new RecentCustomerPurphase
        {
            Id = g.Key.Id,
            FullName = $"{g.Key.FirstName} {g.Key.MiddleName} {g.Key.LastName}".Trim(),
            LastPurchaseDate = g.Max(p => p.PurchaseDate)
        });

        return recentCustomers;

    }

    public Task AddAsync(PurchaseModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(PurchaseModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PurchaseModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PurchaseModel model)
    {
        throw new NotImplementedException();
    }
}
