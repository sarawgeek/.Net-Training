using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class BlogController : Controller
    {
        IConfiguration _config;

        public BlogController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            string loggingLevel = _config.GetSection("Logging").GetSection("LogLevel").GetValue<string>("Microsoft.AspNetCore");
            Person p1 = new Person()
            {
                Name = loggingLevel,
                Age = 34,
                Id = 7113090
            };
            return View(p1);

        }
    }
}
