using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Result([FromForm] Birth model)
        {
            
            if (!model.isValid())
            {
                ViewBag.ErrorMessage = "Imie nie moze byc puste";
                return View("CustomError");
            }
            if((int)(DateTime.Now - model.Date).TotalDays < 0)
            {
                ViewBag.ErrorMessage = "Nie mozesz urodzic sie w przyszlosci!";
                return View("CustomError");
            }
            return View(model);
        }
        public IActionResult Form()
        {
            return View();
        }
    }
}
