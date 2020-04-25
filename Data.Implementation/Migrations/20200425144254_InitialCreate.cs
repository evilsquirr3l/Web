using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                "Productions",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutputDetailId = table.Column<int>(nullable: false),
                    ProductionId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DetailTemplateId = table.Column<int>(nullable: false),
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

            migrationBuilder.InsertData(
                "Categories",
                new[] {"Id", "Name", "Type"},
                new object[] {1, "Some category", "Some type"});

            migrationBuilder.InsertData(
                "Productions",
                new[] {"Id", "CategoryId", "Name"},
                new object[] {1, 1, "Production1"});

            migrationBuilder.InsertData(
                "DetailTemplates",
                new[] {"Id", "OutputDetailId", "ProductionId"},
                new object[] {1, 2, 1});

            migrationBuilder.InsertData(
                "Details",
                new[] {"Id", "CreationTime", "DetailTemplateId", "Name", "ProductionId"},
                new object[]
                {
                    1, new DateTime(2020, 4, 24, 17, 42, 54, 120, DateTimeKind.Local).AddTicks(3620), 1, "Detail 1",
                    null
                });

            migrationBuilder.InsertData(
                "Details",
                new[] {"Id", "CreationTime", "DetailTemplateId", "Name", "ProductionId"},
                new object[]
                {
                    2, new DateTime(2020, 4, 23, 17, 42, 54, 128, DateTimeKind.Local).AddTicks(6230), 1, "Detail 2",
                    null
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