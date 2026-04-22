using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class admincalismasi : Migration
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

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "Calisanlar");

            migrationBuilder.AddColumn<string>(
                name: "Departman",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departman",
                table: "Calisanlar");

            migrationBuilder.AddColumn<int>(
                name: "DepartmanId",
                table: "Calisanlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
