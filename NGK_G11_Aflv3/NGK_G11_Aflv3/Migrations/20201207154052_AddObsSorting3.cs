using Microsoft.EntityFrameworkCore.Migrations;

namespace NGK_G11_Aflv3.Migrations
{
    public partial class AddObsSorting3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Locations");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Observations",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Observations",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Observations");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Locations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Locations",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
