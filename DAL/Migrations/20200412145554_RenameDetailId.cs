using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RenameDetailId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailId",
                table: "DetailTemplates");

            migrationBuilder.AddColumn<int>(
                name: "OutputDetailId",
                table: "DetailTemplates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutputDetailId",
                table: "DetailTemplates");

            migrationBuilder.AddColumn<int>(
                name: "DetailId",
                table: "DetailTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
