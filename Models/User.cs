using System.ComponentModel.DataAnnotations;

namespace HeartDiseasePrediction.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$",
    ErrorMessage = "Only letters allowed")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Required]
        [Range(1, 120,
            ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Mobile number must be 10 digits")]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "User";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public ICollection<Prediction>? Predictions { get; set; }
    }
}
