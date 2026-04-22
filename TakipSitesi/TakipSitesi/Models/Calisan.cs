using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakipSitesi.Models
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "SoyAd alanı zorunludur.")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "KullanıcıAdı alanı zorunludur.")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifre  alanı zorunludur.")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Yaş  alanı zorunludur.")]
        public string Yas { get; set; }
        [Required(ErrorMessage = "Departman alanı zorunludur.")]
        [ForeignKey("Departman")]
        public int DepartmanId { get; set; }
        public Departman? Departman { get; set; }
        [Required(ErrorMessage = "Başlangıç  alanı zorunludur.")]
        public string Baslangic { get; set; }
        public string Resim { get; set; } = "";
        [Required(ErrorMessage = "Telefon Numarası alanı zorunludur.")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Adres  alanı zorunludur.")]
        public string Adres { get; set; }
        public bool IzinDurum { get; set; }
        public DateTime IzinBaslangic { get; set; }
        public DateTime IzinBitis { get; set; }
        [Required(ErrorMessage = "Rol  alanı zorunludur.")]
        public String Role { get; set; }

    }
}
