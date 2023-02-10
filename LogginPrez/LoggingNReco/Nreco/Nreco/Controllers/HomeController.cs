using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nreco.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nreco.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            var result = "Action";
            _logger.LogInformation("Application entered to the index {result}", result);
            try
            {
                int num1 = 5;
                int num2 = 6;

                int[] myArr = new int[num1];
                if(num2>num1)
                    _logger.LogWarning("Number1:{num1} must be greater than Number:{num2}", num1,num2);

                var err = myArr[6];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There are error {result}", result);
            }
            
            return View();
        }

    }
}