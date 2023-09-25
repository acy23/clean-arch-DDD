using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace karavana_INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class Company_Props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Company");
        }
    }
}
