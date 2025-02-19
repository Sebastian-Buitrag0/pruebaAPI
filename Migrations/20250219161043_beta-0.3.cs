using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaAPI.Migrations
{
    /// <inheritdoc />
    public partial class beta03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DataUsers_UserDataId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataUsers",
                table: "DataUsers");

            migrationBuilder.RenameTable(
                name: "DataUsers",
                newName: "UsersData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersData",
                table: "UsersData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersData_UserDataId",
                table: "Users",
                column: "UserDataId",
                principalTable: "UsersData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersData_UserDataId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersData",
                table: "UsersData");

            migrationBuilder.RenameTable(
                name: "UsersData",
                newName: "DataUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataUsers",
                table: "DataUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DataUsers_UserDataId",
                table: "Users",
                column: "UserDataId",
                principalTable: "DataUsers",
                principalColumn: "Id");
        }
    }
}
