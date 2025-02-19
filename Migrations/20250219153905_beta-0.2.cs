using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaAPI.Migrations
{
    /// <inheritdoc />
    public partial class beta02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserDataId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDataId",
                table: "Users",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DataUsers_UserDataId",
                table: "Users",
                column: "UserDataId",
                principalTable: "DataUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DataUsers_UserDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "Users");
        }
    }
}
