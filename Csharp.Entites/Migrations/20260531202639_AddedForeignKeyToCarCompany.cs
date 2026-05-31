using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.Entites.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyToCarCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonEntityID",
                table: "CarCompanies",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_CarCompanies_PersonEntityID",
                table: "CarCompanies",
                column: "PersonEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCompanies_PersonEntity_PersonEntityID",
                table: "CarCompanies",
                column: "PersonEntityID",
                principalTable: "PersonEntity",
                principalColumn: "PersonEntityID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCompanies_PersonEntity_PersonEntityID",
                table: "CarCompanies");

            migrationBuilder.DropIndex(
                name: "IX_CarCompanies_PersonEntityID",
                table: "CarCompanies");

            migrationBuilder.DropColumn(
                name: "PersonEntityID",
                table: "CarCompanies");
        }
    }
}
