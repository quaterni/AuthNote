using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthNote.LocalIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class NamingConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_identity_email",
                table: "identity",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "identity");
        }
    }
}
