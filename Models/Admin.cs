using System.ComponentModel.DataAnnotations;

namespace HeartDiseasePrediction.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}