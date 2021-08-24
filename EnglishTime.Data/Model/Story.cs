using System.ComponentModel.DataAnnotations;

namespace EnglishTime.Data.Model
{
    public class Story
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] File { get; set; }
    }
}