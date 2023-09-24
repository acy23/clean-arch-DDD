using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace karavana_INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class ActivePlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Caravan");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Caravan");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Caravan",
                newName: "Capacity");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Caravan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActiveCaravanPlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaravanId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    PlaceStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveCaravanPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caravan_ActiveCaravanPlaces",
                        column: x => x.CaravanId,
                        principalTable: "Caravan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActiveCaravanPlaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourite_ActiveCaravanPlace",
                        column: x => x.ActiveCaravanPlaceId,
                        principalTable: "ActiveCaravanPlace",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favourite_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveCaravanPlaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_ActiveCaravanPlace",
                        column: x => x.ActiveCaravanPlaceId,
                        principalTable: "ActiveCaravanPlace",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCaravanPlace_CaravanId",
                table: "ActiveCaravanPlace",
                column: "CaravanId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_ActiveCaravanPlaceId",
                table: "Favourite",
                column: "ActiveCaravanPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_UserId",
                table: "Favourite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ActiveCaravanPlaceId",
                table: "Rating",
                column: "ActiveCaravanPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favourite");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "ActiveCaravanPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Caravan");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Caravan",
                newName: "Currency");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Caravan",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Caravan",
                type: "float",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
