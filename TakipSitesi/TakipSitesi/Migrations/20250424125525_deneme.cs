using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
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

            migrationBuilder.DropColumn(
                name: "KimId",
                table: "Izinler");

            migrationBuilder.AlterColumn<string>(
                name: "Durum",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kim",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Oncelik",
                table: "Gorevler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Durum",
                table: "Gorevler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "Kim",
                table: "Izinler");

            migrationBuilder.AlterColumn<int>(
                name: "Durum",
                table: "Izinler",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "KimId",
                table: "Izinler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Oncelik",
                table: "Gorevler",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Durum",
                table: "Gorevler",
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
