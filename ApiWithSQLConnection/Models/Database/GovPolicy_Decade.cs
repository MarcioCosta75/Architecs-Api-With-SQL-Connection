using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class GovPolicy_Decade
    {
        [Key]
        public int PolicyID { get; set; }
        public int Decade { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string Impact { get; set; }
    }
}