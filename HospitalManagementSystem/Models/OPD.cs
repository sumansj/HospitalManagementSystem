using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class OPD
    {
        [Key]
        public int OPDId { get; set; }

        [Required(ErrorMessage = "Name must be filled")]
        [DisplayName("Patient Name")]
        public string FulName { get; set; }

        [Required(ErrorMessage ="Id must be filled")]
        [DisplayName("Patient Id")]
        [ForeignKey("Patients")]
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Disease details must be filled")]
        [DisplayName("Disease Details")]
        public string Disease { get; set; }

        public Patients? Patients { get; set; }

        [DisplayName("Doctor Name")]
        [ForeignKey("Doctors")]
        public int UserId { get; set; }

        [DisplayName("Doctor Name")]
        public Doctors? Doctors { get; set; }

        [DisplayName("Department Name")]
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public Departments? Departments { get; set; }

        [DisplayName("Date")]
        public DateTime? Date { get; set; }
    }
}
