using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagementSystem.Controllers
{
    [Route("Patient")]
    //[Authorize]
    public class PatientController : Controller
    {
        private IHospitalRepo _hospitalrepo;
        private readonly HospitalDbContext _context;

        public PatientController(IHospitalRepo hospitalRepo, HospitalDbContext context)
        {
            _hospitalrepo = hospitalRepo;
            _context = context;
        }

        [HttpPost]
        [Route("GetPatientById")]
        [Authorize(Roles = "Admin,Receptionist")]
        public JsonResult GetPatientById(int patientId)
        {
            //created a patient and doctor object to capture the patient details and doctors details based on patientId
            Patients patients = new Patients();
            Doctors doctors = new Doctors();
            if ((patientId != 0))
            {
                patients = _hospitalrepo.GetPatientDetailsById(patientId);
                doctors = _context.Doctors.Find(patients.UserId);
                ViewBag.patientDetails = doctors;
            }
            return Json(new
            {
                patientName = patients.FulName,
                disease = patients.Disease,
                doctorName = doctors.FullName,
                doctorId = doctors.UserId
            });
        }

        //Patient List Details
        [HttpGet]
        [Route("Patientlist")]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> PatientDetails()
        {
            List<Patients> patient = new List<Patients>();
            patient = _hospitalrepo.GetPatientDetails();
            ViewBag.PatientCount = _hospitalrepo.CountPatients();
            return View(patient);
        }

        [HttpPost]
        [Route("GetPatientByName")]
        [Authorize(Roles = "Admin,Receptionist")]
        public JsonResult GetPatientByName(string name)
        {
            Patients patients = new Patients();
            Doctors doctors = new Doctors();
            Departments departments = new Departments();
            if (!name.IsNullOrEmpty())
            {
                patients = _hospitalrepo.GetPatientsByName(name);
                doctors = _context.Doctors.Find(patients.UserId);   //extracting the doctor name based on doctorId available in patient table
                departments = _context.Departments.Find(patients.DepartmentId);
            }
            return Json(new {
                patientId = patients.PatientId,
                patientName = patients.FulName,
                patientDisease = patients.Disease,
                doctorName = doctors.FullName,
                departmentName = departments.DepartmentName,
                doctorId = doctors.UserId,
                departmentId = departments.DepartmentId
            });
        }
    }
}
