using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class Decade
    {
        [Key]
        public int DecadeValue { get; set; }
    }
}