using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task<bool> UpdateAsync(int id, Product product);
    Task<bool> DeleteAsync(int id);
}