using AutoMapper;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic.Models.Request;
using WebApp.BusinessLogic.Models.Response;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.BusinessLogic.Services;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper automapper;

    public CustomerService(IUnitOfWork unitOfWork, IMapper automapper)
    {
        this.unitOfWork = unitOfWork;
        this.automapper = automapper;
    }

    public async Task<IEnumerable<BirthdayCustomer>> GetBirthdayCustomersAsync(DateTime date)
    {
        var customers = await unitOfWork.CustomerRepository.GetBirthdayCustomers(date);

        return automapper.Map<IEnumerable<BirthdayCustomer>>(customers);
    }

    public Task AddAsync(CustomerModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(CustomerModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CustomerModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CustomerModel model)
    {
        throw new NotImplementedException();
    }


}
