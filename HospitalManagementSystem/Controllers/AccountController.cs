using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("Account")]
    public class AccountController: Controller
    {
        [HttpGet]
        [Authorize]
        [Route("Home")]
        public IActionResult Home(Employees employees)
        {
            return View(employees);
        }

        [HttpGet]
        [Route("AccessDenied")]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
