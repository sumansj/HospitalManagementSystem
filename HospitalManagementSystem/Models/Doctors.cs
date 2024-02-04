using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Doctors
    {
        [Key]
        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name must be filled")]
        [DisplayName("FIrst Name")]
        [Column(TypeName="nvarchar(50)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name must be filled")]
        [DisplayName("Last Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth must be filled")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

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

        [DisplayName("Address")]
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [DisplayName("City")]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [DisplayName("State")]
        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; }

        [DisplayName("Country")]
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        [DisplayName("Role")]
        public IdentityRole RoleId { get; set; }

        [Required(ErrorMessage = "Doctor Registration number must be filled")]
        [DisplayName("Doctor RegNo")]
        [Column(TypeName = "nvarchar(20)")]
        public string DocRegNo { get; set; }

        [Required(ErrorMessage = "Department must be filled")]
        [DisplayName("Department")]
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }

        public Departments? Departments { get; set; }

        [Required(ErrorMessage = "Qualification number must be filled")]
        [DisplayName("Qualification")]
        [Column(TypeName = "nvarchar(100)")]
        public string Qualification { get; set; }

        [DisplayName("Joining Name")]
        public DateTime? JoiningDate { get; set; }

        [DisplayName("End Name")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        public Boolean? IsLeave { get; set; }
    }
}
