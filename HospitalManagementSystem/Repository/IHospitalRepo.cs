using HospitalManagementSystem.Models;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.Repository
{
    public interface IHospitalRepo
    {
        public void AddEmployee(Employees employee);
        public List<Departments> GetDepartments();
        public void AddDoctor(Doctors doctor);
        public List<BloodGroups> GetBloodGroups();
        public List<Genders> GetGenders();
        public List<Doctors> GetDoctors();
        public void AddPatient(Patients patients);
        public int CountPatients();
        public int CountDoctor();
        public List<Doctors> GetDoctorsLeave();
        public int CountRoom();
        public List<Room> GetRoomList();
        public List<Room> GetRooms();
        public List<Room> GetRoomDetails(int roomNo);
        public Patients GetPatientDetailsById(int patientId);
        public void AddBookings(Booking bookings);
        public Employees GetEmpDetails(string email);
        public List<Patients> GetPatientDetails();
        public Patients GetPatientsByName(string name);
        public List<Doctors> GetDoctorsDetails();
        public void AddOPD(OPD opd);
        public List<OPD> OPDList();
        public List<OPD> OPDListToday();
        public Doctors GetDoctorsDetailsById(int employeeId);
        public Booking GetBookingDetailsById(int patientId);
        public List<Booking> GetBookingDetails();
    }
}
