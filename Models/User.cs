using System.ComponentModel.DataAnnotations;
using AdventureLoggerBackend.Data;

namespace AdventureLoggerBackend.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        [Length(5,45)]
        public string UserName { get; set; }
        [Required]
        [Length(5,45)]
        public string Password { get; set; }

        public string Email { get; set; }
        [Required]
        [Length(5,99)]
        public string? profile_picture { get; set; }
    }
}