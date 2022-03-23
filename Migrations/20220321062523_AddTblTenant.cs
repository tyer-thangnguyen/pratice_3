using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice_3.Migrations
{
    public partial class AddTblTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tenant_Id",
                table: "User",
                column: "Id",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tenant_Id",
                table: "User");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
