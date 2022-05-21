using BlogProNew.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProNew.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthController(SignInManager<IdentityUser>signInManager)
        {
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public async Task<  IActionResult> Login(LoginVM loginVM)
        {
            var res = await signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
            return RedirectToAction(nameof(Index), "Admin");
            
        }
        [HttpGet]
        public async Task< IActionResult> Logout()
        {
          await  signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
