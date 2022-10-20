using EFDemo.Models;

namespace EFDemo.Repositories
{
    public class ProductRepository: IProductRepository
    {

        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public int CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.ProductId;
        }

        public int UpdateProduct(Product product)
        {
            var existingproduct = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (existingproduct != null)
            {
                existingproduct.ProductName = product.ProductName;
                existingproduct.Category = product.Category;
                _context.SaveChanges();
            }

            return existingproduct.ProductId;
        }

        public int DeleteProduct(int ProductId)
        {
            var existingproduct = _context.Products.FirstOrDefault(x => x.ProductId == ProductId);

            if (existingproduct != null)
            {
                _context.Products.Remove(existingproduct);
                _context.SaveChanges();
            }

            return ProductId;
        }

    }
}
