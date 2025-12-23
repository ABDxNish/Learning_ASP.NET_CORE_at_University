using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabTaskFinal.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pid",
                table: "Products",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "Cid",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cid",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Pid");
        }
    }
}
