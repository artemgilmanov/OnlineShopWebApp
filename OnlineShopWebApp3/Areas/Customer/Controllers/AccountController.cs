using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Areas.Customer.Model;
using OnlineShopWebApp3.Model;
using OnlineShop.Db.Model;
using Microsoft.AspNetCore.Http;
using System;

namespace OnlineShopWebApp3.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;
        private readonly UserManager<OnlineShop.Db.Model.User> _userManager;
        private readonly SignInManager<OnlineShop.Db.Model.User> _signInManager;

        public AccountController(IUsersManager usersManager, UserManager<OnlineShop.Db.Model.User> userManager, SignInManager<OnlineShop.Db.Model.User> signInManager)
        {
            this.usersManager = usersManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Logout()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            ////havent tested
            //if (register.FirstName == register.LastName)
            //{
            //    ModelState.AddModelError("", "Firstname and Lastname must be different.");
            //}
            ////havent tested
            //if (register.FirstName == register.Password || register.LastName == register.Password)
            //{
            //    ModelState.AddModelError("", "Password must not be the same as Firstname or Lastname.");
            //}

            ////check if a user exists
            //var existingUser = _userManager.FindByEmailAsync(register.Email);
            //if (existingUser!=null)
            //{
            //    ModelState.AddModelError("", "User already exists!");
            //}

            //// add user to DB
            //var user = new OnlineShop.Db.Model.User()
            //{
            //    Email = register.Email,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = $"{register.FirstName} {register.LastName}"
            //};

            //var result = _signInManager.PasswordSignInAsync(login.Email, login.Password, login.Remember, false).Result;




            //assign the role


            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount()
                {
                    Name = $"{register.FirstName} {register.LastName}",
                    Password = register.Password,
                    Email = register.Email,
                });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return RedirectToAction(nameof(Register));
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login { ReturnUrl = returnUrl});

            //return PartialView("_LoginPartial", new Login());
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Content($"{login.Email}-{login.Password}");
            //}
            //if (login.Email == login.Password)
            //{
            //    ModelState.AddModelError("", "E-mail and password must be different.");
            //    return View();
            //}

            //var userAccount = usersManager.TryGetByName(login.Email);

            //if (userAccount == null)
            //{
            //    ModelState.AddModelError("", "The user does not exist. Please create account.");
            //    return View();
            //}

            //if (userAccount.Password != login.Password)
            //{
            //    ModelState.AddModelError("", "Wrong password.");
            //    return View();
            //}

            //return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));

            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.Email, login.Password, login.Remember, false).Result;
                
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "User does not exist, please register.");
                    return View();
                }

                //return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
                return Redirect(login.ReturnUrl);
            }

            return View(login);
        }

    }
}
