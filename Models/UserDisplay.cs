using System.ComponentModel.DataAnnotations;
using MySql.Data;


//This class contains data that contains basic user information that can be displayed on the UI
namespace AdventureLoggerBackend.Models
{
    public class UserDisplay
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        [Length(5,45)]
        public string UserName { get; set; }
        public string? profile_picture { get; set; }
    }
}