namespace WebApp.DataAccess.Interfaces;

public interface IUnitOfWork
{
    ICustomerRepository CustomerRepository { get; }

    ICategoryRepository CategoryRepository { get; }

    IProductRepository ProductRepository { get; }

    IPurchaseRepository PurchaseRepository { get; }

    IPurchaseProductRepository PurchaseProductRepository { get; }

    Task SaveAsync();
}
