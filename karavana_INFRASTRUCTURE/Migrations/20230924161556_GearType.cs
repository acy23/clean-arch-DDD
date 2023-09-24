using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace karavana_INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class GearType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GearType",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GearType",
                table: "Caravan");
        }
    }
}
