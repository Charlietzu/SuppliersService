using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuppliersService.Data.Migrations
{
    public partial class fixingsupplierrelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");
        }
    }
}
