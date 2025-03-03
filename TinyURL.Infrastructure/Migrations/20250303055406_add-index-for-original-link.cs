using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyURL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addindexfororiginallink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OriginalURL",
                table: "Links",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Links_OriginalURL",
                table: "Links",
                column: "OriginalURL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Links_OriginalURL",
                table: "Links");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalURL",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
