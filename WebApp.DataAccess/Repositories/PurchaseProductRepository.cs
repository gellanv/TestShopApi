using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.DataAccess.Repositories;

public class PurchaseProductRepository : IPurchaseProductRepository
{
    private readonly ShopDbContext context;

    public PurchaseProductRepository(ShopDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(PurchaseProduct entity)
    {
        _ = this.context.PurchaseProducts.Add(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async void Delete(PurchaseProduct entity)
    {
        _ = this.context.PurchaseProducts.Remove(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var purchaseProduct = await this.context.PurchaseProducts.FindAsync(id);
        _ = this.context.PurchaseProducts.Remove(purchaseProduct);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PurchaseProduct>> GetAllAsync()
    {
        var purchaseProducts = await this.context.PurchaseProducts
                .Include(p => p.Purchase)
                .Include(p => p.Product)
                .ToListAsync();

        return purchaseProducts;
    }

    public async Task<PurchaseProduct> GetByIdAsync(int id)
    {
        var purchaseProduct = await this.context.PurchaseProducts
                .Include(p => p.Purchase)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == id);

        return purchaseProduct;
    }

    public async void Update(PurchaseProduct entity)
    {
        _ = this.context.PurchaseProducts.Update(entity);
    }
}
