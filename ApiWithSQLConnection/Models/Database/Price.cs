using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithSQLConnection.Models.Database
{
    public class Price
    {
        [Key, ForeignKey("Property")]
        public int PropertyID { get; set; }
        public int Decade { get; set; }
        public string PriceValue { get; set; }
        public string LinkExtractedText { get; set; }
        public string OriginalURL { get; set; }
    }
}