using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using HospitalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("Login")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly UserManager<IdentityUser> _userManager;
        private IHospitalRepo _hospitalrepo;

        public LoginController(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager, IHospitalRepo hospitalrepo)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _hospitalrepo = hospitalrepo;
        }

        //Below method is used to create a Admin account
        [HttpGet]
        [Route("Adminuser")]
        public async Task<IActionResult> AdminCreate()
        {
            var password = "Admin@123#";     //viewModel.FirstName + "@123#";
            var users = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };
            var result = await _userManager.CreateAsync(users, password);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByIdAsync(users.Id);
                await _userManager.AddToRoleAsync(user, "ADMIN");
            }
            return RedirectToAction("Result", "Admin");
        }

        //use to return Login view
        [HttpGet]
        [Route("/")]
        public IActionResult Login()
        {
            return View();
        }

        
        //use to save login details
        [HttpPost]
        [Route("LoginSave")]
        public async Task<IActionResult> LoginSave(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(viewModel.UserName,viewModel.Password,viewModel.RememberMe,false);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index","Home");
                    //Employees employee = new Employees();
                    //employee = _hospitalrepo.GetEmpDetails(viewModel.UserName);
                    //return RedirectToAction("Home", "Account",employee);
                }
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            return View("Login");
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            TempData["logout"] = "successful";
            return RedirectToAction("Login","Login");
        }
    }
}
