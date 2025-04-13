using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.ContactDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async  Task< IActionResult> Create( ContactCreateDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }
            await _contactService.CreateAsync(dto);
            return RedirectToAction("index" , "Home");
        }
    }
}
