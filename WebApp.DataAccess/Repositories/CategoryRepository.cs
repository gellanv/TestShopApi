using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Entities;
using WebApp.DataAccess.Interfaces;

namespace WebApp.DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ShopDbContext context;

    public CategoryRepository(ShopDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(Category entity)
    {
        _ = this.context.Categories.Add(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async void Delete(Category entity)
    {
        _ = this.context.Categories.Remove(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var category = await this.context.Categories.FindAsync(id);
        _ = this.context.Categories.Remove(category);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var categories = await this.context.Categories
                .Include(p => p.Products)
                .ToListAsync();

        return categories;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await this.context.Categories
                .Include(p => p.Products)
                .FirstOrDefaultAsync(p => p.Id == id);

        return category;
    }

    public async void Update(Category entity)
    {
        _ = this.context.Categories.Update(entity);
    }
}
