using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MySql.Data;

namespace AdventureLoggerBackend.Models
{
    [PrimaryKey(nameof(from), nameof(to))]
    public class Friend
    {
        public int from { get; set; }
        public int to { get; set; }
    }
}