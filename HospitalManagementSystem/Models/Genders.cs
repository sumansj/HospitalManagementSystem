using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Genders
    {
        [Key]
        public int GId { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }
    }
}
