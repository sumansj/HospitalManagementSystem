using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagementSystem.Controllers
{
    [Route("Doctor")]
    [Authorize]
    public class DoctorController : Controller
    {
        private IHospitalRepo _hospitalrepo;
        private readonly HospitalDbContext _context;
        public DoctorController(HospitalDbContext context, IHospitalRepo hospitalRepo)
        {
            _context = context;
            _hospitalrepo = hospitalRepo;
        }

        [HttpPost]
        [Route("GetDoctorsByDepartment")]
        public JsonResult GetDoctorsByDepartment(int departmentId)
        {
            List<Doctors> doctorList = new List<Doctors>();
            if ((departmentId != 0))
            {
                doctorList = _context.Doctors.Where(s => s.DepartmentId.Equals(departmentId)).ToList();
            }
            ViewBag.doctorList = doctorList;
            return Json(doctorList);
        }

        [HttpGet]
        [Route("Doctorlist")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DoctorDetails()
        {
            List<Doctors> doctors = new List<Doctors>();
            doctors = _hospitalrepo.GetDoctorsDetails();
            ViewBag.DoctorCount = _hospitalrepo.CountDoctor();
            return View(doctors);
        }

        //[HttpPost]
        //[Route("GetDoctorByName")]
        //public JsonResult GetDoctorByName(string name)
        //{
        //    Doctors doctors = new Doctors();
        //    if (!name.IsNullOrEmpty())
        //    {
        //        doctors = _hospitalrepo.GetPatientsByName(name);
        //    }
        //    return Json(new
        //    {
        //        patientId = patients.PatientId,
        //        patientName = patients.FulName,
        //        patientDisease = patients.Disease
        //    });
        //}
    }
}
