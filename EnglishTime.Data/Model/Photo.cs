using System.ComponentModel.DataAnnotations;

namespace EnglishTime.Data.Model
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] File { get; set; }

        [Required]
        public User User { get; set; }
    }
}