using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace karavana_INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class CaravanImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaravanImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaravanId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaravanImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaravanImage_Caravan",
                        column: x => x.CaravanId,
                        principalTable: "Caravan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaravanImage_CaravanId",
                table: "CaravanImage",
                column: "CaravanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaravanImage");
        }
    }
}
