using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class deskLibraryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Desks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Desks_LibraryId",
                table: "Desks",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Libraries_LibraryId",
                table: "Desks",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Libraries_LibraryId",
                table: "Desks");

            migrationBuilder.DropIndex(
                name: "IX_Desks_LibraryId",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Desks");
        }
    }
}
