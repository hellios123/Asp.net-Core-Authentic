using Microsoft.EntityFrameworkCore.Migrations;

namespace pagesweb.Migrations
{
    public partial class ChngInInitMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.AlterColumn<int>(
                name: "AppUserID",
                table: "Friends",
                nullable: false,
                oldClrType: typeof(int));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AppUserID",
                table: "Friends",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
