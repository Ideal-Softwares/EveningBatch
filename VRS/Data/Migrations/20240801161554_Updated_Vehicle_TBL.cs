using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VRS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Vehicle_TBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "MSVehicle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "MSVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "MSVehicle",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "MSVehicle",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MSVehicle");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "MSVehicle");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MSVehicle");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "MSVehicle");
        }
    }
}
