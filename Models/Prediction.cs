using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeartDiseasePrediction.Models
{
    public class Prediction
    {
        [Key]
        public int Id { get; set; }
        public string? PatientName { get; set; }
        // Foreign Key
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int Age { get; set; }

        public string? Sex { get; set; }

        public string ChestPainType { get; set; }

        public int RestingBP { get; set; }

        public int Cholesterol { get; set; }

        public string FastingBS { get; set; }

        public string RestingECG { get; set; }

        public int MaxHR { get; set; }

        public string ExerciseAngina { get; set; }

        public float Oldpeak { get; set; }

        public string ST_Slope { get; set; }

        public string Result { get; set; }

        public string? DoctorRecommendation { get; set; }

        public string? SuggestedMedicine { get; set; }

        public string? SuggestedTests { get; set; }

        public DateTime PredictionDate { get; set; }
            = DateTime.Now;
        public string? RecommendedBy { get; set; }
        public DateTime? RecommendationDate { get; set; }
    }
}
