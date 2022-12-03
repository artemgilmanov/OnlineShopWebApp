using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Areas.User.Model;
using OnlineShopWebApp3.Model;

namespace OnlineShopWebApp3.Areas.User.Controllers
{
    [Area("User")]

    public class AccountController : Controller
    {
        private readonly IUsersManager _usersManager;

        public AccountController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            //havent tested
            if (register.FirstName == register.LastName)
            {
                ModelState.AddModelError("", "Firstname and Lastname must be different.");
            }
            //havent tested
            if (register.FirstName == register.Password || register.LastName == register.Password)
            {
                ModelState.AddModelError("", "Password must not be the same as Firstname or Lastname.");
            }

            if (ModelState.IsValid)
            {
                _usersManager.Add(new UserAccount()
                {
                    Name = $"{register.FirstName} {register.LastName}",
                    Password = register.Password,
                    Email = register.Email,
                });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return RedirectToAction(nameof(Register));
        }

        public IActionResult Login()
        {
            return View();

            //return PartialView("_LoginPartial", new Login());
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return Content($"{login.Email}-{login.Password}");
            }

            if (login.Email == login.Password)
            {
                ModelState.AddModelError("", "E-mail and password must be different.");
                return View();
            }

            var userAccount = _usersManager.TryGetByName(login.Email);

            if (userAccount == null)
            {
                ModelState.AddModelError("", "The user does not exist. Please create account.");
                //return PartialView("_LoginPartial");
                //return View("_LoginPartial");
                //return RedirectToAction("Index", "HomeController");
                return View();


            }

            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Wrong password.");
                return View();
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));

        }

    }
}
