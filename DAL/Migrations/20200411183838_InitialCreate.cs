using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                "Productions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.Id);
                    table.ForeignKey(
                        "FK_Productions_Categories_CategoryId",
                        x => x.CategoryId,
                        "Categories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DetailTemplates",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailId = table.Column<int>(),
                    ProductionId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTemplates", x => x.Id);
                    table.ForeignKey(
                        "FK_DetailTemplates_Productions_ProductionId",
                        x => x.ProductionId,
                        "Productions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Details",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(),
                    DetailTemplateId = table.Column<int>(),
                    ProductionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        "FK_Details_DetailTemplates_DetailTemplateId",
                        x => x.DetailTemplateId,
                        "DetailTemplates",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Details_Productions_ProductionId",
                        x => x.ProductionId,
                        "Productions",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Details_DetailTemplateId",
                "Details",
                "DetailTemplateId");

            migrationBuilder.CreateIndex(
                "IX_Details_ProductionId",
                "Details",
                "ProductionId");

            migrationBuilder.CreateIndex(
                "IX_DetailTemplates_ProductionId",
                "DetailTemplates",
                "ProductionId");

            migrationBuilder.CreateIndex(
                "IX_Productions_CategoryId",
                "Productions",
                "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Details");

            migrationBuilder.DropTable(
                "DetailTemplates");

            migrationBuilder.DropTable(
                "Productions");

            migrationBuilder.DropTable(
                "Categories");
        }
    }
}