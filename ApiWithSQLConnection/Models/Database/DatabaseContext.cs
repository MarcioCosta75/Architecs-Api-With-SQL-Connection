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
        // Outros DbSets podem ser adicionados aqui conforme necessário

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da chave primária composta para PropertyPricePer_Decade
            modelBuilder.Entity<PropertyPricePer_Decade>()
                .HasKey(pppd => new { pppd.PropertyID, pppd.Decade });

            // Outras configurações do ModelBuilder...
        }
    }
}