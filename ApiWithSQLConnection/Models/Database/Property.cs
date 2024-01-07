using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
    }
}