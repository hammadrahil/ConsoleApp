using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.Entites.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCarCompanyVariable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarName",
                table: "CarCompanies",
                newName: "CarCompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarCompanyName",
                table: "CarCompanies",
                newName: "CarName");
        }
    }
}
