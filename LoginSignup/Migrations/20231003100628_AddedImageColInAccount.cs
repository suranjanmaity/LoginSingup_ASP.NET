using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSignup.Migrations
{
    public partial class AddedImageColInAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Accounts",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Accounts");
        }
    }
}
