using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pagesweb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstMidName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MobileOrEmail = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    MobileOrEmail = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstMidName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    AppUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Friends_AppUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_AppUserID",
                table: "Friends",
                column: "AppUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
