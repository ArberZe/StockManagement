using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Persistence.Migrations
{
    public partial class addCompaniesToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "Name",
                value: "The Coca-Cola Company");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CountryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 3, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Bull GmbH" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CompanyId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CompanyId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                column: "Name",
                value: "Coca Cola");
        }
    }
}
