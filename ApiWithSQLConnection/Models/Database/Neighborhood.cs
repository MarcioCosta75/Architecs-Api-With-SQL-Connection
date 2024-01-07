using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class Neighborhood
    {
        [Key]
        public int NeighborhoodID { get; set; }
        // Additional properties will be added here as needed.
    }
}