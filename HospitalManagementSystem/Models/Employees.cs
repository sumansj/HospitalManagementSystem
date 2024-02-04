using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name must be filled")]
        [DisplayName("First Name")]
        [Column(TypeName = "nvarchar(50)")]
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
        [StringLength(10,ErrorMessage ="Mobile number should not exceed 10 characters")]
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

        //[Required(ErrorMessage = "Role Name must be filled")]
        [DisplayName("Role")]
        public IdentityRole? RoleId { get; set; }

        [Required(ErrorMessage = "Designation must be filled")]
        [DisplayName("Designation")]
        [Column(TypeName = "nvarchar(20)")]
        public string Desgination { get; set; }

        [DisplayName("Joining Name")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate { get; set; }

        [DisplayName("End Name")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? FullName { get; set; }

        public Boolean? IsLeave { get; set; }
    }
}
