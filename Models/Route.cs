using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data;

namespace AdventureLoggerBackend.Models
{
    public class Route
    {
        [Key]
        public int route_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        [Required]
        [Length(5,45)]
        public string name { get; set; }
        public string data {  get; set; }
    }
}