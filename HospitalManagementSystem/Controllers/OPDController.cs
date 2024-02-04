using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using HospitalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HospitalManagementSystem.Controllers
{
    [Route("OPD")]
    [Authorize]
    public class OPDController: Controller
    {
        private IHospitalRepo _hospitalrepo;
        private readonly HospitalDbContext _context;
        public OPDController(IHospitalRepo hospitalRepo, HospitalDbContext context)
        {
            _context = context;
            _hospitalrepo = hospitalRepo;
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            ViewBag.PatientCount = _hospitalrepo.CountPatients();
            ViewBag.DoctorCount = _hospitalrepo.CountDoctor();
            return View();
        }

        [HttpPost]
        [Route("OPDSave")]
        public async Task<IActionResult> OPDSave(OPD opd)
        {
            if (ModelState.IsValid)
            {
                _hospitalrepo.AddOPD(opd);
                return RedirectToAction("Result", "Admin");
            }
            else
            {
                return View("Home",opd);
            }
        }

        //To get Opd patient List
        [HttpGet]
        [Route("OPDList")]
        public async Task<IActionResult> OPDList()
        {
            List<OPD> opdList = new List<OPD>();
            opdList = _hospitalrepo.OPDList();      //Get list of opd details
            List<DoctorsPatientsViewModel> viewModel = new List<DoctorsPatientsViewModel>();
            foreach (var items in opdList)
            {
                var viewModelobj = new DoctorsPatientsViewModel()
                {
                    PatientId = items.PatientId,
                    PatientName = items.FulName,
                    DoctorName = _context.Doctors.Find(items.UserId).FullName,      //extracting the docot fullname. Find method will return the doctor object and from that object we are extrating only fullname
                    DepartmentName = _context.Departments.Find(items.DepartmentId).DepartmentName,
                    Date = DateOnly.FromDateTime((DateTime)items.Date),     //converting DateTime to capture only date
                    Time = TimeOnly.FromDateTime((DateTime)items.Date)      ////converting DateTime to capture only time
                };
                viewModel.Add(viewModelobj);
            }
            return View(viewModel);
        }

        [HttpGet]
        [Route("OPDListToday")]
        public async Task<IActionResult> OPDListToday()
        {
            List<OPD> opdList = new List<OPD>();
            opdList = _hospitalrepo.OPDList();
            List<DoctorsPatientsViewModel> viewModel = new List<DoctorsPatientsViewModel>();
            foreach (var items in opdList)
            {
                var viewModelobj = new DoctorsPatientsViewModel()
                {
                    PatientId = items.PatientId,
                    PatientName = items.FulName,
                    DoctorName = _context.Doctors.Find(items.UserId).FullName,      //extracting the docot fullname. Find method will return the doctor object and from that object we are extrating only fullname
                    DepartmentName = _context.Departments.Find(items.DepartmentId).DepartmentName,
                    Date = DateOnly.FromDateTime((DateTime)items.Date),
                    Time = TimeOnly.FromDateTime((DateTime)items.Date)
                };
                //comparing if date is today's date or not
                if (viewModelobj.Date.Equals(DateOnly.FromDateTime(DateTime.Today)))
                {
                    viewModel.Add(viewModelobj);
                }
            }
            return View(viewModel);
        }
    }
}
