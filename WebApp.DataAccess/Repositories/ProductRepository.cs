using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext context;

    public ProductRepository(ShopDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(Product entity)
    {
        _ = this.context.Products.Add(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async void Delete(Product entity)
    {
        _ = this.context.Products.Remove(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var product = await this.context.Products.FindAsync(id);
        _ = this.context.Products.Remove(product);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await this.context.Products
                .Include(p => p.PurchaseItems)
                .ThenInclude(p => p.Purchase)
                .Include(p => p.Category)
                .ToListAsync();

        return products;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await this.context.Products
                 .Include(p => p.PurchaseItems)
                .ThenInclude(p => p.Purchase)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

        return product;
    }

    public async void Update(Product entity)
    {
        _ = this.context.Products.Update(entity);
    }
}
