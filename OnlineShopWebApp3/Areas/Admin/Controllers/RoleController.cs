using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Areas.Admin.Model;
using OnlineShopWebApp3.Model;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RoleController : Controller
    {
        private readonly IRolesRepository _rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public IActionResult Delete(string name)
        {
            _rolesRepository.Delete(name);
            return RedirectToAction("Roles", "Home", new { area = "Admin" });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (_rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "This role already exists.");
            }
            if (ModelState.IsValid)
            {
                _rolesRepository.Add(role);
                return RedirectToAction("Roles", "Home", new { area = "Admin" });
            }

            return View(role);
            
        }
    }
}
