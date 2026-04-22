using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class admincalismasi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izinler_Calisanlar_KimId",
                table: "Izinler");

            migrationBuilder.DropIndex(
                name: "IX_Izinler_KimId",
                table: "Izinler");

            migrationBuilder.AlterColumn<string>(
                name: "KimId",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "KimId1",
                table: "Izinler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_KimId1",
                table: "Izinler",
                column: "KimId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_Calisanlar_KimId1",
                table: "Izinler",
                column: "KimId1",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izinler_Calisanlar_KimId1",
                table: "Izinler");

            migrationBuilder.DropIndex(
                name: "IX_Izinler_KimId1",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "KimId1",
                table: "Izinler");

            migrationBuilder.AlterColumn<int>(
                name: "KimId",
                table: "Izinler",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_KimId",
                table: "Izinler",
                column: "KimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_Calisanlar_KimId",
                table: "Izinler",
                column: "KimId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
