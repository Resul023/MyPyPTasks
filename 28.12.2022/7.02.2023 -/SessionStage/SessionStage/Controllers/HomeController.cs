using Microsoft.AspNetCore.Mvc;
using SessionStage.Models;
using SessionStage.DATA;
using System.Diagnostics;

namespace SessionStage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}