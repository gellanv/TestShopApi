using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.DataAccess.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ShopDbContext context;

    public CustomerRepository(ShopDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(Customer entity)
    {
        _ = this.context.Customers.Add(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async void Delete(Customer entity)
    {
        _ = this.context.Customers.Remove(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var customer = await this.context.Customers.FindAsync(id);
        _ = this.context.Customers.Remove(customer);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = await this.context.Customers
                .Include(p => p.Purchases)
                .ThenInclude(p => p.PurchaseProducts)
                .ToListAsync();

        return customers;
    }

    public async Task<IEnumerable<Customer>> GetBirthdayCustomers(DateTime date)
    {
        var customers = await this.context.Customers
            .Where(c => c.BirthDate.Day == date.Day && c.BirthDate.Month == date.Month)
            .ToListAsync();

        return customers;
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var customer = await this.context.Customers
                .Include(p => p.Purchases)
                .ThenInclude(p => p.PurchaseProducts)
                .FirstOrDefaultAsync(p => p.Id == id);

        return customer;
    }

    public async void Update(Customer entity)
    {
        _ = this.context.Customers.Update(entity);
    }
}
