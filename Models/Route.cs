using System.ComponentModel;
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
        public int user_id { get; set; }
        [Required]
        [Length(5,45)]
        public string name { get; set; }
        public int distance { get; set; } = 0;
        public string? data { get; set; }
        public int data_points { get; set; } = 0;
    }
}