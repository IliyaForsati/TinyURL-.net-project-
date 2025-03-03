using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyURL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editlink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortCutURL",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "ShortCutURLCode",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortCutURLCode",
                table: "Links");

            migrationBuilder.AddColumn<string>(
                name: "ShortCutURL",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
