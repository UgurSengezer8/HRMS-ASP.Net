using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class deneme3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminAciklama",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminAciklama",
                table: "Izinler");
        }
    }
}
