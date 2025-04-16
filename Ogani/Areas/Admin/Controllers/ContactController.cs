using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.ContactDtos;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Maderator")]

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Index()
    {
        var contactDtos = await _contactService.GetAllAsync();
        return View(contactDtos);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var contactDto = await _contactService.GetAsync(id);

        return View(contactDto);
    }

    public async Task<IActionResult> Answer(int id)
    {
        var contactDto = await _contactService.ContactCreateDtoAsync(id);

        return View(contactDto);
    }
    [HttpPost]
    public async Task<IActionResult> Answer(ContactCreateDto dto)
    {
        var model = await _contactService.SendEmailContact(dto);
        return RedirectToAction("index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _contactService.DeleteAsync(id);
        return RedirectToAction("index");
    }

   
}
