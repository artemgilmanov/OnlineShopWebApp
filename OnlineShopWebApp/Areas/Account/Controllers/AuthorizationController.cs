using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.Account.Model;
using OnlineShopWebApp3.Areas.Brand.Controllers;

namespace OnlineShopWebApp3.Areas.Account.Controllers
{
    [Area("Account")]
    [AllowAnonymous]

    public class AuthorizationController : Controller
    {
        private readonly UserManager<OnlineShop.Db.Model.User> _userManager;
        private readonly SignInManager<OnlineShop.Db.Model.User> _signInManager;

        public AuthorizationController(UserManager<OnlineShop.Db.Model.User> userManager, SignInManager<OnlineShop.Db.Model.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "Brand" });
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new Register { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.FirstName==register.Password)
            {
                ModelState.AddModelError("", "Firstname and Password must be different.");
                return View();
            }

            if (ModelState.IsValid)
            {
                var user = new OnlineShop.Db.Model.User { Email = register.Email, UserName = register.Email };
                var result = _userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait(); //Cookie Authentification

                    TryAssignUserRole(user);

                    return Redirect(register.ReturnUrl ?? "/Brand/Home/Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return View(register);
        }

        private void TryAssignUserRole(OnlineShop.Db.Model.User user)
        {
            try
            {
                _userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch 
            {
                //log see in logging
            }        
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.Email, login.Password, login.Remember, false).Result;

                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Brand/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "User does not exist, please create account.");
                }
            }
            return View(login);
        }

    }
}
