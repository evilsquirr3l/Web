using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
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
                        name: "FK_Productions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailTemplates",
                columns: table => new
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
                        name: "FK_DetailTemplates_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
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
                        name: "FK_Details_DetailTemplates_DetailTemplateId",
                        column: x => x.DetailTemplateId,
                        principalTable: "DetailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 1, "Some category", "Some type" });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[] { 1, 1, "Production1" });

            migrationBuilder.InsertData(
                table: "DetailTemplates",
                columns: new[] { "Id", "OutputDetailId", "ProductionId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CreationTime", "DetailTemplateId", "Name", "ProductionId" },
                values: new object[] { 1, new DateTime(2020, 4, 24, 17, 42, 54, 120, DateTimeKind.Local).AddTicks(3620), 1, "Detail 1", null });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CreationTime", "DetailTemplateId", "Name", "ProductionId" },
                values: new object[] { 2, new DateTime(2020, 4, 23, 17, 42, 54, 128, DateTimeKind.Local).AddTicks(6230), 1, "Detail 2", null });

            migrationBuilder.CreateIndex(
                name: "IX_Details_DetailTemplateId",
                table: "Details",
                column: "DetailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductionId",
                table: "Details",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailTemplates_ProductionId",
                table: "DetailTemplates",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_CategoryId",
                table: "Productions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "DetailTemplates");

            migrationBuilder.DropTable(
                name: "Productions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
