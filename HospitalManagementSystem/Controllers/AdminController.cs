using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using HospitalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Controllers
{
    [Route("Admin")]
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<IdentityUser> _userManager;
        private IHospitalRepo _hospitalrepo;
        private readonly HospitalDbContext _context;


        public AdminController(RoleManager<IdentityRole> rolemanager,IHospitalRepo hospitalrepo,
            UserManager<IdentityUser> userManager, HospitalDbContext context)
        {
            _rolemanager = rolemanager;
            _hospitalrepo = hospitalrepo;
            _userManager = userManager;
            _context = context;
        }

        [Route("Result")]
        [AllowAnonymous]
        public IActionResult Result()
        {
            return View();
        }

        //use for creating new employee
        [Route("CreateEmployee")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEmployee()
        {
            ViewBag.rolename = await _rolemanager.FindByIdAsync("5");
            return View();
        }

        //use to store the employee details into database
        [Route("EmployeeSave")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EmployeeSave(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _hospitalrepo.AddEmployee(employee);
                var password = employee.FirstName + "@123#";
                var users = new IdentityUser
                {
                    UserName = employee.Email,
                    Email = employee.Email
                };

                //use to create a user
                var result = await _userManager.CreateAsync(users, password);
                if (result.Succeeded)
                {
                    //use to find a user by there id
                    var user = await _userManager.FindByIdAsync(users.Id);
                    if ((employee.Desgination).Equals("Receptionist"))
                    {
                        //use to assign role to the user
                        await _userManager.AddToRoleAsync(user, "RECEPTIONIST");
                    }
                    else
                    {
                        //use to assign role to the user
                        await _userManager.AddToRoleAsync(user, "DEFAULT");
                    }
                    //return RedirectToAction("Index", "Home");
                }
                return View("Result");
            }
            else
            {
                //var errors = ModelState.Select(v => v.Value.Errors)
                //                       .Where(y => y.Count>0)
                //                       .ToList();
                return View("CreateEmployee",employee);
            }
        }

        //use to create doctors details
        [HttpGet]
        [Route("CreateDoctors")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateDoctors()
        {
            //extracted the department from department table.
            var departmentname = _hospitalrepo.GetDepartments();
            //Added the first row as a defult --Select Department--
            departmentname.Add(new Departments() { DepartmentId = 0, DepartmentName = "--Select Department--" });
            //created a selectlist to show the department names in a drop down order by department name
            ViewBag.DepartmentDetails = new SelectList(departmentname.OrderBy(s => s.DepartmentName), "DepartmentId", "DepartmentName");
            return View();
        }

        //use to save registered doctors
        [HttpPost]
        [Route("DoctorSave")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DoctorSave(DoctorsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Doctors doctor = new Doctors()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DateOfBirth = viewModel.DateOfBirth,
                    Mobile = viewModel.Mobile,
                    Email = viewModel.Email,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    State = viewModel.State,
                    Country = viewModel.Country,
                    DocRegNo = viewModel.DocRegNo,
                    DepartmentId = viewModel.DepartmentId,
                    Qualification = viewModel.Qualification,
                    JoiningDate = viewModel.JoiningDate,
                    EndDate = viewModel.EndDate,
                };

                _hospitalrepo.AddDoctor(doctor);
                var password = viewModel.FirstName + "@123#";
                var users = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };

                //use to create a user
                var result = await _userManager.CreateAsync(users, password);
                if (result.Succeeded)
                {
                    //use to find a user by there id
                    var user = await _userManager.FindByIdAsync(users.Id);
                    //use to assign role to the user
                    var results = await _userManager.AddToRoleAsync(user, "DOCTOR");
                    return RedirectToAction("Index","Home");
                }
                return View("Result");

            }
            else
            {
                //var errors = ModelState.Select(v => v.Value.Errors)
                //                       .Where(y => y.Count > 0)
                //                       .ToList();
                return View("CreateDoctors", viewModel);
            }
            
        }

        //use to create patient details
        [HttpGet]
        [Route("CreatePatients")]
        [Authorize(Roles = "Admin,Receptionist")]
        public IActionResult CreatePatients()
        {
            //    extract blood group details
            var bloodgroups = _hospitalrepo.GetBloodGroups();
            //    extract gender details
            var gender = _hospitalrepo.GetGenders();
            //    extract department details
            var departmentname = _hospitalrepo.GetDepartments();
            //    extract doctors details
            var doctorname = _hospitalrepo.GetDoctors();

            //Adding the first row for each drop down as default
            bloodgroups.Add(new BloodGroups() { BId = 0, BloodGroupName = "--Select BloodGroup--" });
            gender.Add(new Genders() { GId = 0, Gender = "--Select Gender--" });
            departmentname.Add(new Departments() { DepartmentId = 0, DepartmentName = "--Select Department--" });
            doctorname.Add(new Doctors() { UserId = 0, FullName = "--Select Doctors--" });

            //    create a selectlist to show the department,doctors,gender.blood group in a drop down order by their respective names
            ViewBag.bloodGroupDetails = new SelectList(bloodgroups.OrderBy(b => b.BloodGroupName), "BId", "BloodGroupName");
            ViewBag.genderDetails = new SelectList(gender.OrderBy(g => g.Gender), "GId", "Gender");
            ViewBag.departmentDetails = new SelectList(departmentname.OrderBy(s => s.DepartmentName), "DepartmentId", "DepartmentName");
            ViewBag.doctorDetails = new SelectList(doctorname.OrderBy(d => d.FullName),"UserId","FullName");
            return View();
        }

        //use to save the patient records
        [HttpPost]
        [Route("PatientSave")]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> PatientSave(Patients patients)
        {
            if (ModelState.IsValid)
            {
                _hospitalrepo.AddPatient(patients);
                //ViewBag.FirstName = patients.FirstName;
                //ViewBag.DateofBirth = patients.DateOfBirth;
                //ViewBag.Mobile = patients.Mobile;
                //ViewBag.Email = patients.Email;
                //ViewBag.Address = patients.Address;
                //ViewBag.City = patients.City;
                //ViewBag.Country = patients.Country;
                //ViewBag.State = patients.State;
                //ViewBag.DepartmentId = patients.DepartmentId;
                //ViewBag.DoctorId = patients.UserId;
                return View("Result");
            }
            else
            {
                //var errors = ModelState.Select(v => v.Value.Errors)
                //                       .Where(y => y.Count > 0)
                //                       .ToList();
                return View("CreatePatients", patients);
            }
        }


        //use to list the room details
        [HttpGet]
        [Route("Rooms")]
        [Authorize(Roles = "Admin,Receptionist")]
        public IActionResult RoomDetails()
        {
            int RCount = 0;
            List<Room> room = new List<Room>();
            room = _hospitalrepo.GetRoomList();
            foreach (var item in room)
            {
                if (item.IsAvailable)
                {
                    RCount++;
                }
            }
            ViewBag.RoomCount = _hospitalrepo.CountRoom();
            ViewBag.RoomAvailable = RCount;
            return View(room);
        }

        
        //Get doctor details based on Id
        [HttpPost]
        [Route("GetDoctorDetails/{employeeid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDoctorDetails(int employeeid)
        {
            if (employeeid == 0)
            {
                return NotFound();
            }
            else
            {
                var doctors = _hospitalrepo.GetDoctorsDetailsById(employeeid);
                ViewBag.Date = doctors.DateOfBirth.ToString("dd MMMM yyyy");    //Converting date to specific format    
                ViewBag.Department = _context.Departments.Find(doctors.DepartmentId).DepartmentName;
                return View(doctors);
            }
        }


        //Get patient details based on ID
        [HttpPost]
        [Route("GetPatientDetails/{patientId}")]
        [Authorize(Roles = "Admin,Receptionist")]
        public IActionResult GetPatientDetails(int patientId)
        {
            if(patientId == 0)
            {
                return NotFound();
            }
            else
            {
                var patient = _hospitalrepo.GetPatientDetailsById(patientId);
                ViewBag.DateOfBirth = patient.DateOfBirth.ToString("dd MMMM yyyy");
                ViewBag.DoctorName = _context.Doctors.Find(patient.UserId).FullName;
                ViewBag.Department = _context.Departments.Find(patient.DepartmentId).DepartmentName;
                ViewBag.BloodGroup = _context.BloodGroups.Find(patient.BId).BloodGroupName;
                ViewBag.GenderName = _context.Genders.Find(patient.GId).Gender;
                //ViewBag.AdmissionDate = patient.DateOfAdmission.ToString("dd MMMM yyyy");
                return View(patient);
            }
        }
    }
}