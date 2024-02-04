using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeResult(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry the requested page is not found";
                    break;
            }
            return View("Error");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            TempData["unhandle"] = "successfull";
            //Retrieve the exception details
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = exceptionDetails.Path;
            ViewBag.Message = exceptionDetails.Error.Message;
            ViewBag.StackTrace = exceptionDetails.Error.StackTrace;
            return View();
        }
    }
}
