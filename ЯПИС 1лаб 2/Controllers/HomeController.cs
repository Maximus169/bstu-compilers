using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ЯПИС_1лаб_2.Models;

namespace ЯПИС_1лаб_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Email() => View();
        

        [HttpPost]
        public IActionResult Email(EmailModel model)
        {             
            if (ModelState.IsValid)
            {
                return View(model); 
            }
            return View(model); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}