using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class Neighborhood
    {
        public int NeighborhoodID { get; set; }
        public string Name { get; set; }

        // Outras propriedades e relações...
    }
}