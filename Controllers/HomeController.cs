using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ESRTest.Models;

namespace ESRTest.Controllers
{
    public class HomeController : Controller
    {
        public class Context
        {
            public int testInt { get; set; }
            public string testString { get; set; }
            public string testString2 { get; set; }
            public string resultLogic1 { get; set; }

        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string sResultLogic1 = "";

            for (int i = 1; i <= 100; i++)
            {
                
                if (i % 5 == 0 && i % 3 != 0)
                {
                    sResultLogic1 += (i.ToString() + " = Buzz" + ",");
                }
                else if (i % 5 == 0 && i % 3 == 0)
                {
                    sResultLogic1 += (i.ToString() + " = FizzBuzz" + ",");
                }
                else if(i % 3 == 0)
                {
                    sResultLogic1 += (i.ToString() + " = Fizz" + ",");
                }
                else
                {
                    sResultLogic1 += (i.ToString() + " = Nothing" + ",");
                }
            }

            Context context = new Context
            {
                testInt = 13,
                testString = "Test controller",
                testString2 = "Test controller2",
                resultLogic1 = sResultLogic1
            };
            ViewBag.Message = context;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
