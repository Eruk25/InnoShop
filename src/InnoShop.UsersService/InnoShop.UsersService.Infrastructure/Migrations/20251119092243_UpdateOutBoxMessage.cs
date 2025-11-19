using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoShop.UsersService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOutBoxMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessedAt",
                table: "OutBoxMessages",
                newName: "ProcessedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "OutBoxMessages",
                newName: "OccurredOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessedOn",
                table: "OutBoxMessages",
                newName: "ProcessedAt");

            migrationBuilder.RenameColumn(
                name: "OccurredOn",
                table: "OutBoxMessages",
                newName: "CreatedAt");
        }
    }
}
