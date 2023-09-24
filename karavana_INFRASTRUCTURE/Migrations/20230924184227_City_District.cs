using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace karavana_INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class City_District : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Caravan");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Caravan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caravan_CityId",
                table: "Caravan",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Caravan_DistrictId",
                table: "Caravan",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityId",
                table: "District",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Caravans",
                table: "Caravan",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_District_Caravans",
                table: "Caravan",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Caravans",
                table: "Caravan");

            migrationBuilder.DropForeignKey(
                name: "FK_District_Caravans",
                table: "Caravan");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Caravan_CityId",
                table: "Caravan");

            migrationBuilder.DropIndex(
                name: "IX_Caravan_DistrictId",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Caravan");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
