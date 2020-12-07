using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NGK_G11_Aflv3.Migrations
{
    public partial class AddObsigen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationsId);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    ObservationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    AirPressure = table.Column<float>(nullable: false),
                    LocationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.ObservationsId);
                    table.ForeignKey(
                        name: "FK_Observations_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "LocationsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observations_LocationsId",
                table: "Observations",
                column: "LocationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
