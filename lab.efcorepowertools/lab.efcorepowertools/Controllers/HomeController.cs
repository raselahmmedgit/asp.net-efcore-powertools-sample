using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab.efcorepowertools.Data;
using lab.efcorepowertools.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace lab.efcorepowertools.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
