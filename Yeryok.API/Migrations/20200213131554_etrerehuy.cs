using Microsoft.EntityFrameworkCore.Migrations;

namespace Yeryok.API.Migrations
{
    public partial class etrerehuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Sliders",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Sliders",
                newName: "Image");
        }
    }
}
