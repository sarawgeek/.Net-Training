using EComADO.Models;
using EComADO.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EComADO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        IConfiguration _config;
        ProductRepository _repo;
        public ProductController(IConfiguration config, ProductRepository repo)
        {
            this._config = config;   
            this._repo = repo;  
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _repo.GetAllProducts();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            return Ok(_repo.CreateProduct(product).ToString());
        }

    }
}
