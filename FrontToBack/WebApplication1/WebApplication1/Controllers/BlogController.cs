﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class BlogController : Controller
	{
		
		public IActionResult Blog()
		{
			return View();
		}
		public IActionResult Details() 
		{
			return View();
		}
	}
}
