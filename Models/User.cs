using System.ComponentModel.DataAnnotations;
using MySql.Data;

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
    }
}