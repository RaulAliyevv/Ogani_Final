using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ogani.Business.Dtos.UserDtos;
using Ogani.Core.Entities;

namespace Ogani.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userRolesViewModel = new List<UserWithRoleDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                // Admin rolu varsa siyahıya əlavə etmə
                if (roles.Contains("Admin")) continue;

                userRolesViewModel.Add(new UserWithRoleDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = roles.FirstOrDefault() ?? "None"
                });
            }

            return View(userRolesViewModel);
        }


        public async Task<IActionResult> ChangeRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = _roleManager.Roles
                .Where(r => r.Name != "Admin") 
                .Select(r => r.Name)
                .ToList();

            var currentRoles = await _userManager.GetRolesAsync(user);

            var model = new ChangeUserRoleDto
            {
                UserId = user.Id,
                Email = user.Email,
                CurrentRole = currentRoles.FirstOrDefault(),
                AllRoles = roles
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeRole(ChangeUserRoleDto model)
        {
            if (model.SelectedRole == "Admin")
            {
                return BadRequest("Admin roles cant chooese");
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
            }

            await _userManager.AddToRoleAsync(user, model.SelectedRole);

            return RedirectToAction(nameof(Index));
        }

    }
}
