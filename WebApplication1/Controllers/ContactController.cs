using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        private static Dictionary<int, ContactModel> _contacts = new Dictionary<int, ContactModel>()
        {
            {1, new() {Id=1, Email = "ssdt@wp.pl", FirstName = "Adam", LastName = "Mickiewicz", BirthDate = new DateOnly(2000,11,11) } }
            , {2, new() {Id=2, Email = "ffdsfs@op.pl" , FirstName = "Jan", LastName = "Kowalski", BirthDate = new DateOnly(2000,11,11)}},
            {3, new() {Id=3, Email = "ddfsd@gmai.olcp", FirstName = "Robert", LastName = "Maklowicz", BirthDate = new DateOnly(1999, 02, 02)}}
        };

        private static int currentId = _contacts.Count;
        public IActionResult Index()
        {
            return View(_contacts);
        }
        public ActionResult Add() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Add(ContactModel model) 
        { 
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.Id = ++currentId;
            _contacts.Add(model.Id, model);

            return View("Index", _contacts);
        }
        public ActionResult Edit(int id)
        {
            return View("Add", _contacts[id]);
        }   
        public ActionResult Delete(int id)
        {
            _contacts.Remove(id);
            return View("Index", _contacts);
        }
        public ActionResult Details(int id)
        {
            return View(_contacts[id]);
        }
    }
}
