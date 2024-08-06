using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_Category_Brand_Vehicle_TBLs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MSBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MSCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MSVehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelYear = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RentPerHour = table.Column<double>(type: "float", nullable: false),
                    VehicleImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MSVehicle_MSBrand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "MSBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MSVehicle_MSCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MSCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MSVehicle_BrandId",
                table: "MSVehicle",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_MSVehicle_CategoryId",
                table: "MSVehicle",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSVehicle");

            migrationBuilder.DropTable(
                name: "MSBrand");

            migrationBuilder.DropTable(
                name: "MSCategory");
        }
    }
}
