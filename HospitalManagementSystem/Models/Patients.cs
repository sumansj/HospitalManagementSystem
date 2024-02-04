using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Patients
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage ="First Name must be filled")]
        [DisplayName("First Name")]
        [Column(TypeName ="nvarchar(50)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name must be filled")]
        [DisplayName("Last Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth must be filled")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="Disease details must be filled")]
        [DisplayName("Disease Details")]
        [Column(TypeName ="nvarchar(150)")]
        public string Disease { get; set; }

        [Required(ErrorMessage = "Department must be filled")]
        [DisplayName("Department")]
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }

        public Departments? Departments { get; set; }

        [DisplayName("Doctor")]
        [ForeignKey("Doctors")]
        public int UserId { get; set; }

        public Doctors? Doctors { get; set; }

        [Required(ErrorMessage ="Blood Group must be filled")]
        [DisplayName("Blood Group")]
        [ForeignKey("BloodGroups")]
        public int BId { get; set; }

        public BloodGroups? BloodGroups { get; set; }

        [Required(ErrorMessage ="Gender details must be filled")]
        [DisplayName("Gender")]
        [ForeignKey("Genders")]
        public int GId { get; set; }

        public Genders? Genders { get; set; }

        public int? Age { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? FulName { get; set; }

        [DisplayName("Address")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Address { get; set; }

        [DisplayName("City")]
        [Column(TypeName = "nvarchar(50)")]
        public string? City { get; set; }

        [DisplayName("State")]
        [Column(TypeName = "nvarchar(50)")]
        public string? State { get; set; }

        [DisplayName("Country")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Mobile Number must be filled")]
        [DisplayName("Mobile")]
        [Column(TypeName = "nvarchar(10)")]
        [StringLength(10, ErrorMessage = "Mobile number should not exceed 10 characters")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email must be filled")]
        [DisplayName("Email")]
        [Column(TypeName = "nvarchar(50)")]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime? DateOfAdmission { get; set; }

        [Required(ErrorMessage = "Attendent name must be filled")]
        [DisplayName("Attendent Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string AttendantName { get; set; }

        [Required(ErrorMessage = "Attendant mobile Number must be filled")]
        [DisplayName("Attendent Mobile")]
        [Column(TypeName = "nvarchar(10)")]
        [StringLength(10, ErrorMessage = "Mobile number should not exceed 10 characters")]
        public string AttendentMobile { get; set; }

        [Required(ErrorMessage = "Attendent email must be filled")]
        [DisplayName("Attendent Email")]
        [Column(TypeName = "nvarchar(50)")]
        [EmailAddress]
        public string AttendentEmail { get; set; }

        public Boolean? IsDischarge { get; set; }
    }
}
