using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deiba.Areas.Identity.Data;
using Deiba.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deiba.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Loginconfirm(LoginViewModel model,[FromServices] UserManager<ApplicationUser> userManager,[FromServices]SignInManager<ApplicationUser> signInManager )
        {
           ApplicationUser user= await userManager.FindByNameAsync(model.Email );
            if (user!=null)
            {
                var s = await signInManager.PasswordSignInAsync(user, model.Password, model.Rememberme, true);
                if (s.Succeeded)
                {
                    TempData["msg"] = "شما با موفقیت لاگین کردید";
                    return RedirectToAction("Index", "Home");
                }
                else if (s.IsLockedOut)
                {
                        TempData["msg"] = "نام کاربری شما یک دقیقه غیر فعال شد";

                }
                else
                {
                       TempData["msg"] = "نام کاربری شما اشتباه است";
                }
                   
            }
                
                return RedirectToAction("Login", "Account");
                
        }
        public async Task<IActionResult> Signout([FromServices] SignInManager<ApplicationUser> signInManager)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


           

        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult>  Registerconfirm(RegisterViewModel model,[FromServices] UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    Name=model.Name,
                    Family=model.Family,
                    UserName=model.Email,
                    Email=model.Email,
                    EmailConfirmed=true
                };
                await userManager.CreateAsync(user, model.Password);
            }
            return RedirectToAction("Login");
        }
    }
}
