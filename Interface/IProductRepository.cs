using E_Commerce.Models;

namespace E_Commerce.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByNameAsync(string name);

        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool Save();

    }
}
