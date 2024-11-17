using System;
using KikoStore.Core.Entities;

namespace KikoStore.Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type,string? sort);
    Task<IReadOnlyList<string>> GetBrandsAsync();
    Task<IReadOnlyList<string>> GetTypesAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> AddProductAsync(Product product);   
    void Update(Product product);
    void Delete(Product product);
    bool IsProductExsits(int id);
    Task<bool> SaveChangesAsync();


}
