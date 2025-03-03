using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API.Migrations
{
    public partial class FixDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNasc",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNasc",
                table: "AspNetUsers");
        }
    }
}
