using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class BloodGroups
    {
        [Key]
        public int BId { get; set; }

        [DisplayName("Blood Group")]
        public string BloodGroupName { get; set; }
    }
}
