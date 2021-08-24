using System.ComponentModel.DataAnnotations;

namespace EnglishTime.Data.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}