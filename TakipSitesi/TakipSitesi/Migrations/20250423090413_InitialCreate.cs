using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakipSitesi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false),
                    Baslangic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IzinDurum = table.Column<bool>(type: "bit", nullable: false),
                    IzinBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisanlar_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oncelik = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    KimId = table.Column<int>(type: "int", nullable: false),
                    Detay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gorevler_Calisanlar_KimId",
                        column: x => x.KimId,
                        principalTable: "Calisanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izinler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KimId = table.Column<int>(type: "int", nullable: false),
                    Baslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izinler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izinler_Calisanlar_KimId",
                        column: x => x.KimId,
                        principalTable: "Calisanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_DepartmanId",
                table: "Calisanlar",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_KimId",
                table: "Gorevler",
                column: "KimId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_KimId",
                table: "Izinler",
                column: "KimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "Izinler");

            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "Departmanlar");
        }
    }
}
