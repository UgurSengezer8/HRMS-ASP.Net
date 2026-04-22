using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class den7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Departmanlar_DepartmanId",
                table: "Calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_DepartmanId",
                table: "Calisanlar");

            migrationBuilder.RenameColumn(
                name: "DepartmanId",
                table: "Departmanlar",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmanId",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departmanlar",
                newName: "DepartmanId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "Calisanlar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_DepartmanId",
                table: "Calisanlar",
                column: "DepartmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Departmanlar_DepartmanId",
                table: "Calisanlar",
                column: "DepartmanId",
                principalTable: "Departmanlar",
                principalColumn: "DepartmanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
