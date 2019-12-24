using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aventude.Demo.eShop.Data.Migrations
{
    public partial class NavigationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompactCatalogItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactCatalogItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_BrandId",
                table: "CatalogItem",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_TypeId",
                table: "CatalogItem",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItem_CatalogBrand_BrandId",
                table: "CatalogItem",
                column: "BrandId",
                principalTable: "CatalogBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItem_CatalogType_TypeId",
                table: "CatalogItem",
                column: "TypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItem_CatalogBrand_BrandId",
                table: "CatalogItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItem_CatalogType_TypeId",
                table: "CatalogItem");

            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropTable(
                name: "CatalogType");

            migrationBuilder.DropTable(
                name: "CompactCatalogItems");

            migrationBuilder.DropIndex(
                name: "IX_CatalogItem_BrandId",
                table: "CatalogItem");

            migrationBuilder.DropIndex(
                name: "IX_CatalogItem_TypeId",
                table: "CatalogItem");
        }
    }
}
