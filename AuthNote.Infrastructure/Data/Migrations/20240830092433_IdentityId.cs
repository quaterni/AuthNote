using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthNote.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityId",
                table: "User",
                column: "IdentityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_IdentityId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "FirstName");
        }
    }
}
