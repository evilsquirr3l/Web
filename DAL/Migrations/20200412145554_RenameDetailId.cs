using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RenameDetailId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "DetailId",
                "DetailTemplates");

            migrationBuilder.AddColumn<int>(
                "OutputDetailId",
                "DetailTemplates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "OutputDetailId",
                "DetailTemplates");

            migrationBuilder.AddColumn<int>(
                "DetailId",
                "DetailTemplates",
                "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}