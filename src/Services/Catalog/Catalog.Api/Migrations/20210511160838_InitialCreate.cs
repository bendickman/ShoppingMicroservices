using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageFile = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTimestamp", "Name", "UpdatedTimestamp" },
                values: new object[] { 1, new DateTime(2021, 5, 11, 17, 8, 37, 835, DateTimeKind.Local).AddTicks(5018), "Mobile Phones", new DateTime(2021, 5, 11, 17, 8, 37, 838, DateTimeKind.Local).AddTicks(5739) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTimestamp", "Name", "UpdatedTimestamp" },
                values: new object[] { 2, new DateTime(2021, 5, 11, 17, 8, 37, 838, DateTimeKind.Local).AddTicks(6541), "Audio Visual", new DateTime(2021, 5, 11, 17, 8, 37, 838, DateTimeKind.Local).AddTicks(6560) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTimestamp", "Name", "UpdatedTimestamp" },
                values: new object[] { 3, new DateTime(2021, 5, 11, 17, 8, 37, 838, DateTimeKind.Local).AddTicks(6565), "Clothing", new DateTime(2021, 5, 11, 17, 8, 37, 838, DateTimeKind.Local).AddTicks(6568) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFile", "Name", "Price", "Summary" },
                values: new object[] { 1, 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "product-1.png", "iPhone 12", 899.99m, "Latest iPhone 12 with Night Mode" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFile", "Name", "Price", "Summary" },
                values: new object[] { 2, 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "product-2.png", "Panasonic 60 inch TV", 1999.99m, "Big screen TV with Ultra HD" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFile", "Name", "Price", "Summary" },
                values: new object[] { 3, 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "product-3.png", "North Face Hoody", 49.99m, "Extra warm fleece hoody" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
