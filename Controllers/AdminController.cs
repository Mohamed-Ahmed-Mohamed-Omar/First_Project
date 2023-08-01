using First_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace First_Project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var data = _roleManager.Roles; 

            return View(data);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if(ModelState.IsValid)
            {
                var data = new IdentityRole()
                {
                    Name = model.RoleName
                };

                var result = await _roleManager.CreateAsync(data);

                if(result.Succeeded)
                {
                    return RedirectToAction("CreateRole");   
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> EditRole(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);

            var data = new EditRoleVM()
            {
                Id = result.Id,
                RoleName = result.Name
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {
            if(ModelState.IsValid) 
            {
                var result = await _roleManager.FindByIdAsync(model.Id);

                result.Name = model.RoleName;

                var role = await _roleManager.UpdateAsync(result);

                if (role.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in role.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);

            var data = new DeleteRoleVM()
            {
                Id = result.Id,
                RoleName = result.Name
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(DeleteRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.FindByIdAsync(model.Id);

                var role = await _roleManager.DeleteAsync(result);

                if (role.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in role.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}
