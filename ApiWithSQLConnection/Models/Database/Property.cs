using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }
        public int Year { get; set; }
        public string PropertyType { get; set; }
        public float Price { get; set; }
        public string LinkExtractedText { get; set; }
        public string OriginalURL { get; set; }
    }
}