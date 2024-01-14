using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiWithSQLConnection.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Decades",
                columns: table => new
                {
                    DecadeValue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decades", x => x.DecadeValue);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Government_Policies",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    LinkExtractedText = table.Column<string>(type: "longtext", nullable: false),
                    Impact = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    OriginalURL = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Government_Policies", x => x.PolicyID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GovernmentPolicy_Performances",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Impact = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentPolicy_Performances", x => x.PolicyID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GovPolicy_Decades",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Decade = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Impact = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovPolicy_Decades", x => x.PolicyID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.NeighborhoodID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PropertyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Decade = table.Column<int>(type: "int", nullable: false),
                    PriceValue = table.Column<string>(type: "longtext", nullable: false),
                    LinkExtractedText = table.Column<string>(type: "longtext", nullable: false),
                    OriginalURL = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PropertyID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<float>(type: "float", nullable: false),
                    LinkExtractedText = table.Column<string>(type: "longtext", nullable: false),
                    OriginalURL = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PropertyPricePer_Decades",
                columns: table => new
                {
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Decade = table.Column<string>(type: "varchar(255)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPricePer_Decades", x => new { x.PropertyID, x.Decade });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSentiment_Decades",
                columns: table => new
                {
                    SentimentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Decade = table.Column<int>(type: "int", nullable: false),
                    SentimentScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSentiment_Decades", x => x.SentimentID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSentiment_Neighborhoods",
                columns: table => new
                {
                    SentimentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SentimentScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSentiment_Neighborhoods", x => x.SentimentID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSentiments",
                columns: table => new
                {
                    SentimentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "longtext", nullable: false),
                    SentimentScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkExtractedText = table.Column<string>(type: "longtext", nullable: false),
                    OriginalURL = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSentiments", x => x.SentimentID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Decades",
                column: "DecadeValue",
                values: new object[]
                {
                    1960,
                    1970,
                    1980,
                    1990,
                    2000,
                    2010,
                    2020
                });

            migrationBuilder.InsertData(
                table: "Neighborhoods",
                columns: new[] { "NeighborhoodID", "Name" },
                values: new object[,]
                {
                    { 1, "Belém" },
                    { 2, "Alcântara" },
                    { 3, "Baixa" },
                    { 4, "Benfica" },
                    { 5, "Laranjeiras" },
                    { 6, "Alameda" },
                    { 7, "Penha De França" },
                    { 8, "Lumiar" },
                    { 9, "Alvalade" },
                    { 10, "Olivais" },
                    { 11, "Parque Das Nações" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionID", "Name" },
                values: new object[] { 1, "Lisboa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Decades");

            migrationBuilder.DropTable(
                name: "Government_Policies");

            migrationBuilder.DropTable(
                name: "GovernmentPolicy_Performances");

            migrationBuilder.DropTable(
                name: "GovPolicy_Decades");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyPricePer_Decades");

            migrationBuilder.DropTable(
                name: "PublicSentiment_Decades");

            migrationBuilder.DropTable(
                name: "PublicSentiment_Neighborhoods");

            migrationBuilder.DropTable(
                name: "PublicSentiments");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
