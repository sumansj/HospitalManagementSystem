using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalManagementSystem.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHospitalRepo _hospitalrepo;

        public HomeController(ILogger<HomeController> logger, IHospitalRepo hospitalRepo)
        {
            _hospitalrepo = hospitalRepo;
            _logger = logger;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            
            ViewBag.PatientCount = _hospitalrepo.CountPatients();
            ViewBag.DoctorCount = _hospitalrepo.CountDoctor();
            return View(_hospitalrepo.GetDoctorsLeave());
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}