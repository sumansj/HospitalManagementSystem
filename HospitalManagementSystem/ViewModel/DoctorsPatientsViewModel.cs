using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.ViewModel
{
    public class DoctorsPatientsViewModel
    {
        public int PatientId { set; get; }
        public string PatientName { set; get; }
        public string DoctorName { set; get; }
        public string DepartmentName { set; get; }
        public DateOnly? Date { set; get; }
        public TimeOnly? Time { set; get; }
    }
}
