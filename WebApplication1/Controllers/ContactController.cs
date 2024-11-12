using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }
        public ActionResult Add() 
        { 
            var model = new ContactModel();
            model.Organizations = _contactService.FindAllOrganizations()
                .Select(o => new SelectListItem() 
                { 
                    Value = o.Id.ToString(),
                    Text = o.Name,
                    Selected = o.Id == 1
                }
                ).ToList();
            return View("Add", model);
        }
        [HttpPost]
        public ActionResult Add(ContactModel model) 
        { 
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            _contactService.Add(model);

            return View("Index", _contactService.FindAll());
        }
        public ActionResult Edit(int id)
        {
            return View("Edit", _contactService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _contactService.Update(model);
            
            return View("Index", _contactService.FindAll());
        }   
        public ActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return View("Index", _contactService.FindAll());
        }
        public ActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }
    }
}
