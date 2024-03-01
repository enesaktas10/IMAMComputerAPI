using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMAMComputerAPI.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Baskets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserID",
                table: "Baskets",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserID",
                table: "Baskets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserID",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Baskets");
        }
    }
}
