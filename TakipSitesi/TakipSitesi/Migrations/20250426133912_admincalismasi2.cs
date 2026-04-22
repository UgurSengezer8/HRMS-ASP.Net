using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class admincalismasi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kim",
                table: "Izinler");

            migrationBuilder.AddColumn<int>(
                name: "KimId",
                table: "Izinler",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Kim",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
