using System.ComponentModel.DataAnnotations;

namespace EnglishTime.Data.Model
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }

        [Required]
        public short Points { get; set; }

        [Required]
        public User User { get; set; }
    }
}