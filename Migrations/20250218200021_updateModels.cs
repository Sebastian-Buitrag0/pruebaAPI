using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pruebaAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");
        }
    }
}
