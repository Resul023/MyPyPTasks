using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MvcTest.Controllers;
public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Info()
        {
            return "This is test";
        }
        public string Info2(string name, int num = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {num}");
        }
        public IActionResult Info3(string name, int num = 1)
        {
            ViewData["Message"] =  name;
            ViewData["Num"] = num;
            return View();
        }
    }