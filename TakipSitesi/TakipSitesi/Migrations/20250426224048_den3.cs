using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class den3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmanId",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartmanId1",
                table: "Calisanlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_DepartmanId1",
                table: "Calisanlar",
                column: "DepartmanId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Departmanlar_DepartmanId1",
                table: "Calisanlar",
                column: "DepartmanId1",
                principalTable: "Departmanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Departmanlar_DepartmanId1",
                table: "Calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_DepartmanId1",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "DepartmanId1",
                table: "Calisanlar");
        }
    }
}
