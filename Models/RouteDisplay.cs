using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data;

namespace AdventureLoggerBackend.Models
{
    public class RouteDisplay
    {
        [Key]
        public int route_id { get; set; }
        //public UserDisplay? User { get; set; }
        [Required]
        [Length(5,45)]
        public string name { get; set; }
        public int distance { get; set; } = 0;
        public int data_points { get; set; } = 0;
    }
}