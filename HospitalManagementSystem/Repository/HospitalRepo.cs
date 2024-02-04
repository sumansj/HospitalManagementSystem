using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Numerics;

namespace HospitalManagementSystem.Repository
{
    public class HospitalRepo : IHospitalRepo
    {
        private readonly HospitalDbContext _context;
        public HospitalRepo(HospitalDbContext context) 
        { 
            _context = context;
        }

        public HospitalRepo(string name) { }

        //Use to add new Employee
        public void AddEmployee(Employees employee)
        {
            //_context.add(employee);
            //_context.savechanges();
            var FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar)
            {
                Value = employee.FirstName
            };
            
            var LastName = new SqlParameter("@LastName", SqlDbType.NVarChar)
            {
                Value = employee.LastName
            };

            var DateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.DateTime2)
            {
                Value = employee.DateOfBirth
            };

            var Mobile = new SqlParameter("@Mobile", SqlDbType.NVarChar)
            {
                Value = employee.Mobile
            };

            var Email = new SqlParameter("@Email", SqlDbType.NVarChar)
            {
                Value = employee.Email
            };

            var Address = new SqlParameter("@Address", SqlDbType.NVarChar)
            {
                Value = employee.Address
            };

            var City = new SqlParameter("@City", SqlDbType.NVarChar)
            {
                Value = employee.City
            };

            var State = new SqlParameter("@State", SqlDbType.NVarChar)
            {
                Value = employee.State
            };

            var Country = new SqlParameter("@Country", SqlDbType.NVarChar)
            {
                Value = employee.Country
            };

            var Desgination = new SqlParameter("@Desgination", SqlDbType.NVarChar)
            {
                Value = employee.Desgination
            };

            var JoiningDate = new SqlParameter("@JoiningDate", SqlDbType.DateTime2)
            {
                //checking if field has null value will update null.
                Value = (employee.JoiningDate == null) ? DBNull.Value : employee.JoiningDate.Value
            };

            var EndDate = new SqlParameter("@EndDate", SqlDbType.DateTime2)
            {
                //checking if field has null value will update null.
                Value = (employee.EndDate == null) ? DBNull.Value : employee.EndDate.Value
            };

            //Calling the insert employees procedure
            _context.Database.ExecuteSqlRaw("Exec SP_InsertEmployees @FirstName, @LastName," +
                "@DateOfBirth, @Mobile, @Email, @Address, @City, @State, @Country, @Desgination," +
                "@JoiningDate, @EndDate",FirstName,LastName,DateOfBirth,Mobile,Email,Address,City,State,
                Country,Desgination,JoiningDate,EndDate);
        }

        //Use to extract department list
        public List<Departments> GetDepartments()
        {
            var departmentList = _context.Departments.FromSql($"select * from Departments").ToList();
            return (departmentList);
            //return (_context.Departments.ToList());
        }

        //Use to add new doctor
        public void AddDoctor(Doctors doctor)
        {
            var FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar)
            {
                Value = doctor.FirstName
            };

            var LastName = new SqlParameter("@LastName", SqlDbType.NVarChar)
            {
                Value = doctor.LastName
            };

            var DateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.NVarChar)
            {
                Value = doctor.DateOfBirth
            };

            var Mobile = new SqlParameter("@Mobile", SqlDbType.NVarChar)
            {
                Value = doctor.Mobile
            };

            var Email = new SqlParameter("@Email", SqlDbType.NVarChar)
            {
                Value = doctor.Email
            };

            var Address = new SqlParameter("@Address", SqlDbType.NVarChar)
            {
                Value = doctor.Address
            };

            var City = new SqlParameter("@City", SqlDbType.NVarChar)
            {
                Value = doctor.City
            };

            var State = new SqlParameter("@State", SqlDbType.NVarChar)
            {
                Value = doctor.State
            };

            var Country = new SqlParameter("@Country", SqlDbType.NVarChar)
            {
                Value = doctor.Country
            };

            var DocRegNo = new SqlParameter("@DocRegNo", SqlDbType.NVarChar)
            {
                Value = doctor.DocRegNo
            };

            var DepartmentId = new SqlParameter("@DepartmentId", SqlDbType.NVarChar)
            {
                Value = doctor.DepartmentId
            };

            var Qualification = new SqlParameter("@Qualification", SqlDbType.NVarChar)
            {
                Value = doctor.Qualification
            };

            var JoiningDate = new SqlParameter("@JoiningDate", SqlDbType.NVarChar)
            {
                Value = (doctor.JoiningDate == null) ? DBNull.Value : doctor.JoiningDate.Value
            };

            var EndDate = new SqlParameter("@EndDate", SqlDbType.NVarChar)
            {
                Value = (doctor.EndDate == null) ? DBNull.Value : doctor.EndDate.Value
            };

            _context.Database.ExecuteSqlRaw("Exec SP_InsertDoctors @FirstName,@LastName,@DateOfBirth,@Mobile," +
                "@Email,@Address,@City,@State,@Country,@DocRegNo,@DepartmentId,@Qualification,@JoiningDate," +
                "@EndDate",FirstName,LastName,DateOfBirth,Mobile,Email,Address,City,State,Country,DocRegNo,
                DepartmentId,Qualification,JoiningDate,EndDate);
        }

        //extarct the blood group list and return them
        public List<BloodGroups> GetBloodGroups()
        {
            return (_context.BloodGroups.ToList());
        }

        //extract the genders details and return them
        public List<Genders> GetGenders()
        {
            return (_context.Genders.ToList());
        }

        public List<Doctors> GetDoctors()
        {
            return (_context.Doctors.ToList());
        }

        public void AddPatient(Patients patients)
        {
            var FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar)
            {
                Value = patients.FirstName
            };

            var LastName = new SqlParameter("@LastName", SqlDbType.NVarChar)
            {
                Value = patients.LastName
            };

            var DateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.NVarChar)
            {
                Value = patients.DateOfBirth
            };

            var Disease = new SqlParameter("@Disease", SqlDbType.NVarChar)
            {
                Value = patients.Disease
            };

            var DepartmentId = new SqlParameter("@DepartmentId", SqlDbType.NVarChar)
            {
                Value = patients.DepartmentId
            };

            var UserId = new SqlParameter("@UserId", SqlDbType.NVarChar)
            {
                Value = patients.UserId
            };

            var BId = new SqlParameter("@BId", SqlDbType.NVarChar)
            {
                Value = patients.BId
            };

            var GId = new SqlParameter("@GId", SqlDbType.NVarChar)
            {
                Value = patients.GId
            };

            var Address = new SqlParameter("@Address", SqlDbType.NVarChar)
            {
                Value = patients.Address
            };

            var City = new SqlParameter("@City", SqlDbType.NVarChar)
            {
                Value = patients.City
            };

            var State = new SqlParameter("@State", SqlDbType.NVarChar)
            {
                Value = patients.State
            };

            var Country = new SqlParameter("@Country", SqlDbType.NVarChar)
            {
                Value = patients.Country
            };

            var Mobile = new SqlParameter("@Mobile", SqlDbType.NVarChar)
            {
                Value = patients.Mobile
            };

            var Email = new SqlParameter("@Email", SqlDbType.NVarChar)
            {
                Value = patients.Email
            };

            var AttendantName = new SqlParameter("@AttendantName", SqlDbType.NVarChar)
            {
                Value = patients.AttendantName
            };

            var AttendentMobile = new SqlParameter("@AttendentMobile", SqlDbType.NVarChar)
            {
                Value = patients.AttendentMobile
            };

            var AttendentEmail = new SqlParameter("@AttendentEmail", SqlDbType.NVarChar)
            {
                Value = patients.AttendentEmail
            };

            _context.Database.ExecuteSqlRaw("Exec SP_InsertPatients @FirstName,@LastName,@DateOfBirth,@Disease," +
                "@DepartmentId,@UserId,@BId,@GId,@Address,@City,@State,@Country,@Mobile,@Email," +
                "@AttendantName,@AttendentMobile,@AttendentEmail", FirstName, LastName, DateOfBirth, Disease,
                DepartmentId, UserId, BId, GId, Address, City, State, Country, Mobile, Email, AttendantName,
                AttendentMobile, AttendentEmail);
        }

        public int CountPatients()
        {
            var isDischarge = false;
            return (_context.Patients.Where(p => p.IsDischarge == isDischarge).Count());
        }

        public int CountDoctor()
        {
            return (_context.Doctors.Count());
        }

        public List<Doctors> GetDoctorsLeave()
        {
            var propValue = true;
            //executing sql query to get the list of doctors who are on leave
            var doctorList = _context.Doctors.FromSql($"select * from Doctors where IsLeave = {propValue}").ToList();
            return doctorList;
        }

        public int CountRoom()
        {
            return (_context.Room.ToList().Count);
        }

        public List<Room> GetRoomList()
        {
            var roomList = _context.Room.FromSql($"select * from Room").ToList();
            return (roomList);
        }

        public List<Room> GetRooms()
        {
            var propValue = true;
            var roomNo = _context.Room.FromSql($"select * from Room where IsAvailable = {propValue}").ToList();
            return (roomNo);
        }

        public List<Room> GetRoomDetails(int roomNo)
        {
            var propVaule1 = roomNo;
            var roomNos = _context.Room.FromSql($"select * from Room where RoomNo = {propVaule1}")
                                      .ToList();
            return (roomNos);
        }

        public Patients GetPatientDetailsById(int patientId)
        {
            var sql = "select * from Patients where PatientId = @patientId";
            var patients = _context.Patients.FromSqlRaw(sql, new SqlParameter("@patientId", patientId))
                                            .FirstOrDefault();
            return patients;
        }

        public void AddBookings(Booking bookings)
        {
            var PatientId = new SqlParameter("@PatientId", SqlDbType.Int)
            {
                Value = bookings.PatientId
            };

            var FullName = new SqlParameter("@FullName", SqlDbType.NVarChar)
            {
                Value = bookings.FullName
            };

            var Disease = new SqlParameter("@Disease", SqlDbType.NVarChar)
            {
                Value = bookings.Disease
            };

            var UserId = new SqlParameter("@UserId", SqlDbType.Int)
            {
                Value = bookings.UserId
            };

            var RoomNo = new SqlParameter("@RoomNo", SqlDbType.Int)
            {
                Value = bookings.RoomNo
            };

            var DischargeDate = new SqlParameter("@DischargeDate", SqlDbType.DateTime2)
            {
                Value = (bookings.DischargeDate == null) ? DBNull.Value : bookings.DischargeDate.Value
            };

            _context.Database.ExecuteSqlRaw("Exec SP_InsertBookings @PatientId, @FullName, @Disease, @UserId, @RoomNo, @DischargeDate", PatientId, FullName, Disease, UserId, RoomNo, DischargeDate);
        }

        public Employees GetEmpDetails(string email)
        {
            var sql = "select * from Employees where Email = @email";
            var employees = _context.Employees.FromSqlRaw(sql, new SqlParameter("@email", email))
                                              .FirstOrDefault();
            return employees;
        }

        public List<Patients> GetPatientDetails()
        {
            return (_context.Patients.ToList());
        }

        public Patients GetPatientsByName(string name)
        {
            var sql = "select * from Patients where FulName = @FulName";
            var patients = _context.Patients.FromSqlRaw(sql, new SqlParameter("@FulName", name))
                                            .FirstOrDefault();
            return patients;
        }

        public List<Doctors> GetDoctorsDetails()
        {
            return (_context.Doctors.ToList());
        }

        public void AddOPD(OPD opd)
        {
            var FulName = new SqlParameter("@FulName", SqlDbType.NVarChar)
            {
                Value = opd.FulName
            };

            var PatientId = new SqlParameter("@PatientId", SqlDbType.Int)
            {
                Value = opd.PatientId
            };

            var Disease = new SqlParameter("@Disease", SqlDbType.NVarChar)
            {
                Value = opd.Disease
            };

            var UserId = new SqlParameter("@UserId", SqlDbType.Int)
            {
                Value = opd.UserId
            };

            var DepartmentId = new SqlParameter("@DepartmentId", SqlDbType.Int)
            {
                Value = opd.DepartmentId
            };

            _context.Database.ExecuteSqlRaw("EXEC SP_InsertOPD @FulName,@PatientId,@Disease,@UserId," +
                "@DepartmentId", FulName, PatientId, Disease, UserId, DepartmentId);
        }

        public List<OPD> OPDList()
        {
            var sqlQuery = "select a.OPDId,a.PatientId,a.FulName,a.Date,b.FullName,b.UserId," +
                "c.DepartmentId,c.DepartmentName,a.Disease " +
                "from Opds a inner join Doctors b on a.UserId = b.UserId inner join Departments c " +
                "on a.DepartmentId = c.DepartmentId;";
            var opdList = _context.Opds.FromSqlRaw(sqlQuery).ToList();
            
            return opdList;
        }

        public List<OPD> OPDListToday()
        {
            var propValue = DateOnly.FromDateTime(DateTime.Today);
            var result = _context.Opds.FromSql($"select * from Opds where Date = {propValue}")
                                      .ToList();
            return result;
        }

        public Doctors GetDoctorsDetailsById(int employeeId)
        {
            var sql = "select * from Doctors where EmployeeId = @employeeId";
            var doctors = _context.Doctors.FromSqlRaw(sql, new SqlParameter("@employeeId",employeeId))
                                           .FirstOrDefault();
            return doctors;
        }

        public Booking GetBookingDetailsById(int patientId)
        {
            var sql = "select * from Bookings where PatientId = @patientId";
            var bookings = _context.Bookings.FromSqlRaw(sql, new SqlParameter("@patientId", patientId))
                                            .FirstOrDefault();
            return bookings;
        }

        public List<Booking> GetBookingDetails()
        {
            var bookingList = _context.Bookings.FromSql($"select * from Bookings").ToList();
            return bookingList;
        }
    }
}