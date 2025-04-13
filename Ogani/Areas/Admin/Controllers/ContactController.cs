using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Services.Abstractions;

namespace Ogani.Areas.Admin.Controllers;

[Area("Admin")]
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
        var contactDto = await _contactService.GetAsync(id);

        return View(contactDto);
    }

   
}
