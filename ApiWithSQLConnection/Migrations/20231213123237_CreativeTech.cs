using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiWithSQLConnection.Migrations
{
    /// <inheritdoc />
    public partial class CreativeTech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Courid = table.Column<int>(name: "Cour_id", type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Courname = table.Column<string>(name: "Cour_name", type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Courid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Stuid = table.Column<int>(name: "Stu_id", type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Stuname = table.Column<string>(name: "Stu_name", type: "longtext", nullable: false),
                    Stuplace = table.Column<string>(name: "Stu_place", type: "longtext", nullable: false),
                    Stubdate = table.Column<DateTime>(name: "Stu_bdate", type: "datetime(6)", nullable: false),
                    Stugender = table.Column<string>(name: "Stu_gender", type: "longtext", nullable: false),
                    Stuemail = table.Column<string>(name: "Stu_email", type: "longtext", nullable: false),
                    CourseCourid = table.Column<int>(name: "CourseCour_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Stuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
