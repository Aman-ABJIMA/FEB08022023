using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(AppDbContext dbContext,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            var respose = new LoginVM();
            return View(respose);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
           if(!ModelState.IsValid)
           {
                return View(loginVM);
           }
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordCheck)
                {
                    //Password is correct
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
              
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index","home");
                    }
                }
                //Password incorrect
                 TempData["Error"] = "Wrong credentials.Please, try again!!";
                 return View(loginVM);
            }
            //User Not Found
            TempData["Error"] = "Wrong Credentials";
            return View(loginVM);
        }
    }
}
