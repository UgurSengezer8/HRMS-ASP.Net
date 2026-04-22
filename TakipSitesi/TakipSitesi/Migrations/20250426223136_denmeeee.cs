using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class denmeeee : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId1",
                table: "Calisanlar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmanId",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<string>(
                name: "DepartmanId1",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
