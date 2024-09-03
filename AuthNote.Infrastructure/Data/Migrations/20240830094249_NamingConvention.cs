using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthNote.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NamingConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_User_UserId",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "user",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "user",
                newName: "identity_id");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "user",
                newName: "ix_user_email");

            migrationBuilder.RenameIndex(
                name: "IX_User_IdentityId",
                table: "user",
                newName: "ix_user_identity_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "note",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "note",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "note",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "note",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Note_UserId",
                table: "note",
                newName: "ix_note_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_note",
                table: "note",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_note_user_user_id",
                table: "note",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_note_user_user_id",
                table: "note");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_note",
                table: "note");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "note",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "identity_id",
                table: "User",
                newName: "IdentityId");

            migrationBuilder.RenameIndex(
                name: "ix_user_email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "ix_user_identity_id",
                table: "User",
                newName: "IX_User_IdentityId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Note",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Note",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Note",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Note",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "ix_note_user_id",
                table: "Note",
                newName: "IX_Note_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_User_UserId",
                table: "Note",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
