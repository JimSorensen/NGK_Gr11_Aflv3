using Microsoft.EntityFrameworkCore.Migrations;

namespace NGK_G11_Aflv3.Migrations
{
    public partial class AddObsSorting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Observations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Observations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sorting",
                table: "Observations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Sorting",
                table: "Observations");
        }
    }
}
