using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Repositories;

namespace WebApp.DataAccess.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ShopDbContext _context;
    private ICustomerRepository customerRepository;
    private ICategoryRepository categoryRepository;
    private IProductRepository productRepository;
    private IPurchaseRepository purchaseRepository;
    private IPurchaseProductRepository purchaseProductRepository;

    private bool disposed;

    public UnitOfWork(ShopDbContext context)
    {
        _context = context;
    }

    public ICustomerRepository CustomerRepository
    {
        get
        {
            customerRepository ??= new CustomerRepository(_context);
            return customerRepository;
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            categoryRepository ??= new CategoryRepository(_context);
            return categoryRepository;
        }
    }

    public IProductRepository ProductRepository
    {
        get
        {
            productRepository ??= new ProductRepository(_context);
            return productRepository;
        }
    }

    public IPurchaseRepository PurchaseRepository
    {
        get
        {
            purchaseRepository ??= new PurchaseRepository(_context);
            return purchaseRepository;
        }
    }

    public IPurchaseProductRepository PurchaseProductRepository
    {
        get
        {
            purchaseProductRepository ??= new PurchaseProductRepository(_context);
            return purchaseProductRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed && disposing)
        {
            _context.Dispose();
        }

        disposed = true;
    }
}
