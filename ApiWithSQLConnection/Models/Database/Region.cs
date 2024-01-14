using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class Region
    {
        [Key]
        public int RegionID { get; set; }

        public string Name { get; set; }
        // Additional properties will be added here as needed.
    }
}