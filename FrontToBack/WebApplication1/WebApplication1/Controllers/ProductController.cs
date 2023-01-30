using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class ProductController : Controller
	{
		
		public IActionResult Details()
		{
			return View();
		}
	}
}
