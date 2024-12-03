using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.DataAccess.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly ShopDbContext context;

    public PurchaseRepository(ShopDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Purchase>> GetRecentPurphaseAsync(int days)
    {
        var cutoffDate = DateTime.UtcNow.AddDays(-days);

        return await this.context.Purchases
            .Include(p => p.Customer)
            .Where(p => p.PurchaseDate >= cutoffDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Purchase>> GetPurchaseByCustomerAsync(int customerId)
    {
        var purchases = await context.Purchases
        .Where(p => p.CustomerId == customerId)
        .Include(p => p.PurchaseProducts)
        .ThenInclude(p => p.Product)
        .ThenInclude(c => c.Category)
        .ToListAsync();
        return purchases;
    }

    public async Task AddAsync(Purchase entity)
    {
        _ = this.context.Purchases.Add(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async void Delete(Purchase entity)
    {
        _ = this.context.Purchases.Remove(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var purchase = await this.context.Purchases.FindAsync(id);
        _ = this.context.Purchases.Remove(purchase);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Purchase>> GetAllAsync()
    {
        var purchases = await this.context.Purchases
                .Include(p => p.PurchaseProducts)
                .ThenInclude(p => p.Product)
                .ToListAsync();

        return purchases;
    }

    public async Task<Purchase> GetByIdAsync(int id)
    {
        var purchase = await this.context.Purchases
               .Include(p => p.PurchaseProducts)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == id);

        return purchase;
    }

    public async void Update(Purchase entity)
    {
        _ = this.context.Purchases.Update(entity);
    }

}
