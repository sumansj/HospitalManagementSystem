using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Controllers
{
    [Route("Receptionist")]
    //[Authorize(Roles = "Receptionist")]
    public class ReceptionistController: Controller
    {
        private IHospitalRepo _hospitalrepo;
        private readonly HospitalDbContext _context;
        public ReceptionistController(IHospitalRepo hospitalrepo, HospitalDbContext context)
        {
            _hospitalrepo = hospitalrepo;
            _context = context;
        }

        [Route("Result")]
        [AllowAnonymous]
        public IActionResult Result()
        {
            return View();
        }

        [Route("Home")]
        [Authorize(Roles = "Receptionist")]
        public IActionResult Home(Employees employees)
        {
            return View(employees);
        }

        //use to create patient details
        //[HttpGet]
        //[Route("CreatePatients")]
        //public IActionResult CreatePatients()
        //{
        //    //    extract blood group details
        //    var bloodgroups = _hospitalrepo.GetBloodGroups();
        //    //    extract gender details
        //    var gender = _hospitalrepo.GetGenders();
        //    //    extract department details
        //    var departmentname = _hospitalrepo.GetDepartments();
        //    //    extract doctors details
        //    var doctorname = _hospitalrepo.GetDoctors();

        //    //Adding the first row for each drop down as default
        //    bloodgroups.Add(new BloodGroups() { BId = 0, BloodGroupName = "--Select BloodGroup--" });
        //    gender.Add(new Genders() { GId = 0, Gender = "--Select Gender--" });
        //    departmentname.Add(new Departments() { DepartmentId = 0, DepartmentName = "--Select Department--" });
        //    doctorname.Add(new Doctors() { UserId = 0, FullName = "--Select Doctors--" });

        //    //    create a selectlist to show the department,doctors,gender.blood group in a drop down order by their respective names
        //    ViewBag.bloodGroupDetails = new SelectList(bloodgroups.OrderBy(b => b.BloodGroupName), "BId", "BloodGroupName");
        //    ViewBag.genderDetails = new SelectList(gender.OrderBy(g => g.Gender), "GId", "Gender");
        //    ViewBag.departmentDetails = new SelectList(departmentname.OrderBy(s => s.DepartmentName), "DepartmentId", "DepartmentName");
        //    ViewBag.doctorDetails = new SelectList(doctorname.OrderBy(d => d.FullName), "UserId", "FullName");
        //    return View();
        //}

        //use to save the patient records
        //[HttpPost]
        //[Route("PatientSave")]
        //public async Task<IActionResult> PatientSave(Patients patients)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _hospitalrepo.AddPatient(patients);
        //        //ViewBag.FirstName = patients.FirstName;
        //        //ViewBag.DateofBirth = patients.DateOfBirth;
        //        //ViewBag.Mobile = patients.Mobile;
        //        //ViewBag.Email = patients.Email;
        //        //ViewBag.Address = patients.Address;
        //        //ViewBag.City = patients.City;
        //        //ViewBag.Country = patients.Country;
        //        //ViewBag.State = patients.State;
        //        //ViewBag.DepartmentId = patients.DepartmentId;
        //        //ViewBag.DoctorId = patients.UserId;
        //        return View("Debug");
        //    }
        //    else
        //    {
        //        //var errors = ModelState.Select(v => v.Value.Errors)
        //        //                       .Where(y => y.Count > 0)
        //        //                       .ToList();
        //        return View("CreatePatients", patients);
        //    }
        //}

        //[HttpGet]
        //public IActionResult RoomDetails()
        //{
        //    int RCount = 0;
        //    List<Room> room = new List<Room>();
        //    room = _hospitalrepo.GetRoomList();
        //    foreach (var item in room)
        //    {
        //        if (item.IsAvailable)
        //        {
        //            RCount++;
        //        }
        //    }
        //    ViewBag.RoomCount = _hospitalrepo.CountRoom();
        //    ViewBag.RoomAvailable = RCount;
        //    return View(room);
        //}

        [HttpGet]
        [Route("Booking")]
        [Authorize(Roles = "Receptionist")]
        public IActionResult CreateBooking()
        {
            //extract list of rooms
            var roomdetails = _hospitalrepo.GetRooms();

            //Adding the first row as default
            roomdetails.Add(new Room() { RoomNo = 0, RoomType = "--Select RoomNo--" });

            //creating a selectlist to show the room type details
            ViewBag.roomDetails = new SelectList(roomdetails.OrderBy(r => r.RoomNo), "RoomNo", "RoomType");
            return View();
        }

        //use to save bookings
        [HttpPost]
        [Route("BookingSave")]
        [Authorize(Roles = "Receptionist")]
        public async Task<IActionResult> BookingSave(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var bookings = _hospitalrepo.GetBookingDetailsById(booking.PatientId);
                if(bookings != null)
                {
                    ViewBag.patientName = booking.FullName;
                    ViewBag.roomNo = bookings.RoomNo;
                    TempData["data"] = "successful";
                    return View("CreateBooking", booking);
                }
                else
                {
                    _hospitalrepo.AddBookings(booking);
                    //ViewBag.PatientId = booking.PatientId;
                    //ViewBag.FullName = booking.FullName;
                    //ViewBag.Disease = booking.Disease;
                    //ViewBag.Doctor = booking.UserId;
                    //ViewBag.RoomNo = booking.RoomNo;
                    return View("Result");
                }
            }
            else
            {
                return View("CreateBooking",booking);
            }
        }


        //get booking details
        [HttpGet]
        [Route("BookingDetails")]
        public async Task<IActionResult> GetBookingDetails()
        {
            List<Booking> bookingdetails = _hospitalrepo.GetBookingDetails();
            return View(bookingdetails);
        }
        //user profile details
        [HttpGet]
        [Route("Profile")]
        public IActionResult UserProfile(string email)
        {
            Employees employee = new Employees();
            employee = _hospitalrepo.GetEmpDetails(email);
            return View(employee);
        }

    }
}
