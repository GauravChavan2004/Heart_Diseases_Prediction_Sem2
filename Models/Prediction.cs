using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeartDiseasePrediction.Models
{
    public class Prediction
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$",
        ErrorMessage = "Only letters allowed")]
        [Required(ErrorMessage = "Patient Name is required")]
        public string PatientName { get; set; } = string.Empty;
        // Foreign Key
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        [Required(ErrorMessage = "Patient Age is required")]
        public int? Age { get; set; }

        [Required]
        public string? Sex { get; set; }

        [Required]
        public string ChestPainType { get; set; }

        [Range(50, 300, ErrorMessage = "BP must be between 50 and 300")]
        [Required(ErrorMessage = "RestingBP is required")]
        public int? RestingBP { get; set; }

        [Range(50, 700, ErrorMessage = "Cholesterol must be between 50 and 700")]
        [Required(ErrorMessage = "Cholesterol is required")]
        public int? Cholesterol { get; set; }
        [Required]
        public string FastingBS { get; set; }
        [Required]
        public string RestingECG { get; set; }

        [Range(50, 250, ErrorMessage = "Heart Rate must be between 50 and 250")]
        [Required(ErrorMessage = "Heart Rate is required")]
        public int? MaxHR { get; set; }
        [Required]
        public string ExerciseAngina { get; set; }

        [Range(0, 10, ErrorMessage = "Oldpeak must be between 0 and 10")]
        [Required(ErrorMessage = "Oldpeak is required")]
        public float? Oldpeak { get; set; }

        [Required]
        public string ST_Slope { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;
        public string? DoctorRecommendation { get; set; }

        public string? SuggestedMedicine { get; set; }

        public string? SuggestedTests { get; set; }

        public DateTime PredictionDate { get; set; }
            = DateTime.Now;
        public string? RecommendedBy { get; set; }
        public DateTime? RecommendationDate { get; set; }
    }
}
