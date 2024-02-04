using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Room
    {
        [Key]

        public int RoomNo { get; set; }

        [DisplayName("Room Type")]
        public string RoomType { get; set; }

        public Boolean IsAvailable { get; set; }
    }
}
