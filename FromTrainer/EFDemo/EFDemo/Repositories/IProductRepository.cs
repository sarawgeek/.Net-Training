using EFDemo.Models;

namespace EFDemo.Repositories
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetProducts();

        int CreateProduct(Product product);

        int UpdateProduct(Product product); 

        int DeleteProduct(int ProductId); 
    }
}
