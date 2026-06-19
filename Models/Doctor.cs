using System.ComponentModel.DataAnnotations;

namespace HeartDiseasePrediction.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Doctor Name is required")]
        [StringLength(50)]
        public string DoctorName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string HospitalName { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$",
         ErrorMessage = "Enter valid 10 digit mobile number")]
        public string MobileNo { get; set; }

        [Required]
        [Range(0, 50)]
        public int Experience { get; set; }

        [Required]
        [StringLength(20,
         MinimumLength = 6,
         ErrorMessage = "Password must be 6 to 20 characters")]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
