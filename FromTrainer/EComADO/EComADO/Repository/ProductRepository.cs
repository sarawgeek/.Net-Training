using EComADO.AL;
using EComADO.Models;
using System.Data.SqlClient;

namespace EComADO.Repository
{
    public class ProductRepository
    {

        SQLUtil _db;

        List<Product> products = new List<Product>();

        public ProductRepository(SQLUtil db)
        {
            _db = db;
        }


        public int CreateProduct(Product product)
        {
            SqlCommand sqlcommand = _db.getCommand("insert into products (productName, categoryName) values ('" + product.ProductName + "', '" + product.Category + "')", _db.getConnection());
            int affectedRows = sqlcommand.ExecuteNonQuery();
            return affectedRows;
        }

        public List<Product> GetAllProducts()
        {
            products = new List<Product>();
            SqlDataReader reader = _db.getReader("select * from products");

            while (reader.Read())
            {
                products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }


            return products;
        }

        public void DeleteProduct()
        {

        }

        public void UpdateProduct()
        {

        }

        public void SearchProduct()
        {

        }
    }
}
