using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [DisplayName("Patient Id")]
        [ForeignKey("Patients")]
        public int PatientId { get; set; }

        [Required]
        [DisplayName("Patient FullName")]
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Disease")]
        [Column(TypeName = "nvarchar(150)")]
        public string Disease { get; set; }

        public Patients? Patients { get; set; }

        [DisplayName("Doctor Name")]
        [ForeignKey("Doctors")]
        public int UserId { get; set; }

        [DisplayName("Doctor Name")]
        public Doctors? Doctors { get; set; }

        [DisplayName("RoomNo")]
        [ForeignKey("Room")]
        public int RoomNo { get; set; }

        public Room? Room { get; set; }

        [DisplayName("Admission Date")]
        public DateTime? AddmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }

        public int? Duration { get; set; }

        public Boolean? IsBillPaid { get; set; }
    }
}
