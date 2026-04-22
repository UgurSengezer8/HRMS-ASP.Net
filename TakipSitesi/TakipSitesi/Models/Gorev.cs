using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TakipSitesi.Models
{
    public class Gorev
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Aciklama { get; set; }
        public string CalisanAciklama { get; set; } = "";
        [Required(ErrorMessage = "Öncelik alanı zorunludur.")]
        public string Oncelik { get; set; }
        [Required(ErrorMessage = "Durum alanı zorunludur.")]
        public string Durum { get; set; }
        [ForeignKey("Kim")]
        public int KimId { get; set; }

        public Calisan Kim { get; set; }
        [Required(ErrorMessage = "Detay alanı zorunludur.")]
        public string Detay { get; set; }
    }
}
