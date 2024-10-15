using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
/*        public IActionResult Calculator(Operator? op, double? a, double? b)
        {
            if(op is null)
            {
                ViewBag.ErrorMessage = "Niepoprawny format operatora";
                return View("CustomError");
            }
            if (a is null || b is null)
            {
                ViewBag.ErrorMessage = "Niepoprawny format liczby";
                return View("CustomError");
            }

            ViewBag.op = op;
            ViewBag.a = a; 
            ViewBag.b = b;
            
                switch(op)
            {

                case Operator.add:
                    ViewBag.result = a+b;
                    ViewBag.op = "+";
                    break;
                case Operator.sub:
                    ViewBag.result = a - b;
                    ViewBag.op = "-";
                    break;
                case Operator.mul:
                    ViewBag.result = a * b;
                    ViewBag.op = "×";
                    break;
                case Operator.div:
                    ViewBag.result = a / b;
                    ViewBag.op = "÷";
                    break;
                default:
                    ViewBag.ErrorMessage = "Niepoprawny znak dzialania";
                    return View("CustomError");
                    
            }
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public enum Operator 
        { 
        mul, div, add, sub
        }
    }
}
