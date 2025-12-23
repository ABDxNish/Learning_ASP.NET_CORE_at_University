using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabTaskFinal.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeySolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_ctgId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ctgId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ctgId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Cid",
                table: "Products",
                column: "Cid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Cid",
                table: "Products",
                column: "Cid",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Cid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Cid",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ctgId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ctgId",
                table: "Products",
                column: "ctgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_ctgId",
                table: "Products",
                column: "ctgId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
