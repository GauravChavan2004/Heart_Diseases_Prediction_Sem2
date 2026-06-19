using System.ComponentModel.DataAnnotations;

namespace HeartDiseasePrediction.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
