using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.Entites.Migrations
{
    /// <inheritdoc />
    public partial class AddedFoodCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCompany",
                columns: table => new
                {
                    FoodCompanyID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FoodCompanyName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCompany", x => x.FoodCompanyID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodCompany");
        }
    }
}
