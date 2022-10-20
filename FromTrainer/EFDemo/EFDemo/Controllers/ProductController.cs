using EFDemo.Models;
using EFDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        
        IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            return _repository.GetProducts();
        }

        [HttpPost()]
        public int Create([FromBody] Product product)
        {
            return _repository.CreateProduct(product);
        }

        [HttpPut()]
        public int Update([FromBody] Product product)
        {
            return _repository.UpdateProduct(product);  

        }


        [HttpDelete]
        public int Delete(int productId)
        {
            return _repository.DeleteProduct(productId);
        }
    }
}
