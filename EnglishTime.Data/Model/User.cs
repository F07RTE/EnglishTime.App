using System.ComponentModel.DataAnnotations;

namespace EnglishTime.Data.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }
       
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }
        
        [MaxLength(250)]
        public string JobTitle { get; set; }
        
        [MinLength(8)]
        [MaxLength(25)]
        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}