using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthNote.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Note",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Note",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Note");
        }
    }
}
