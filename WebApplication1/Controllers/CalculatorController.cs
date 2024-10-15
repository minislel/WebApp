using Microsoft.AspNetCore.Mvc;
using static WebApplication1.Controllers.HomeController;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
        public enum Operator
        {
            mul, div, add, sub
        }
        public IActionResult Form()
        {
            return View();
        }
    }

}
