using System.ComponentModel.DataAnnotations;

namespace EnglishTime.Data.Model
{
    public class Tip
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        [Required]
        public string Phrase { get; set; }

        [MaxLength(1000)]       
        public string Description { get; set; }

        [MaxLength(1000)]
        public string Example { get; set; }
    }
}