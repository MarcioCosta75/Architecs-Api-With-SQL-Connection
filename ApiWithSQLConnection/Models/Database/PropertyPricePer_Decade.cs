using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithSQLConnection.Models.Database
{
    public class PropertyPricePer_Decade
    {
        [ForeignKey("Property")]
        public int PropertyID { get; set; }
        public int Decade { get; set; }
        public decimal Price { get; set; }
    }
}