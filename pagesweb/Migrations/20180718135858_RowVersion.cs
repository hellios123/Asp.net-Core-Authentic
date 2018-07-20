using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pagesweb.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AppUsers",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AppUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Friends",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
