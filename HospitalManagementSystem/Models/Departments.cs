using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
    }
}
