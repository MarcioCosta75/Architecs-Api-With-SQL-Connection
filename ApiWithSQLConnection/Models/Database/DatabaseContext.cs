using Microsoft.EntityFrameworkCore;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace ApiWithSQLConnection.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<GovPolicy_Decade> GovPolicy_Decades { get; set; }
        public DbSet<PublicSentiment_Decade> PublicSentiment_Decades { get; set; }
        public DbSet<PublicSentiment_Neighborhood> PublicSentiment_Neighborhoods { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Decade> Decades { get; set; }
        public DbSet<PropertyPricePer_Decade> PropertyPricePer_Decades { get; set; }
        public DbSet<PublicSentiment> PublicSentiments { get; set; }
        public DbSet<GovernmentPolicy_Performance> GovernmentPolicy_Performances { get; set; }
        public DbSet<Government_Policy> Government_Policies { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration of the composite primary key for PropertyPricePer_Decade
            modelBuilder.Entity<PropertyPricePer_Decade>()
                .HasKey(pppd => new { pppd.PropertyID, pppd.Decade });

            // Seeding to the Decade table
            modelBuilder.Entity<Decade>().HasData(
                new Decade { DecadeValue = 1960 },
                new Decade { DecadeValue = 1970 },
                new Decade { DecadeValue = 1980 },
                new Decade { DecadeValue = 1990 },
                new Decade { DecadeValue = 2000 },
                new Decade { DecadeValue = 2010 },
                new Decade { DecadeValue = 2020 }
            );

            // Seeding to the Neighborhood table
            modelBuilder.Entity<Neighborhood>().HasData(
                new Neighborhood { NeighborhoodID = 1, Name = "Belém" },
                new Neighborhood { NeighborhoodID = 2, Name = "Alcântara" },
                new Neighborhood { NeighborhoodID = 3, Name = "Baixa" },
                new Neighborhood { NeighborhoodID = 4, Name = "Benfica" },
                new Neighborhood { NeighborhoodID = 5, Name = "Laranjeiras" },
                new Neighborhood { NeighborhoodID = 6, Name = "Alameda" },
                new Neighborhood { NeighborhoodID = 7, Name = "Penha De França" },
                new Neighborhood { NeighborhoodID = 8, Name = "Lumiar" },
                new Neighborhood { NeighborhoodID = 9, Name = "Alvalade" },
                new Neighborhood { NeighborhoodID = 10, Name = "Olivais" },
                new Neighborhood { NeighborhoodID = 11, Name = "Parque Das Nações" }
            );

            // Seeding to the Region table
            modelBuilder.Entity<Region>().HasData(
                new Region { RegionID = 1, Name = "Lisboa" }
            );

        }
    }
}