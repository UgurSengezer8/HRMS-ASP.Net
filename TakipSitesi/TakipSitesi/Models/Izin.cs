using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TakipSitesi.Models
{
    public class Izin
    {
        public int Id { get; set; }
        public string KimId { get; set; }

        public Calisan Kim { get; set; }
        [Required(ErrorMessage = "Başlangıç alanı zorunludur.")]
        public DateTime Baslangic { get; set; }
        [Required(ErrorMessage = "Bitiş alanı zorunludur.")]
        public DateTime Bitis { get; set; }
        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]

        public string Aciklama { get; set; }
        public string AdminAciklama { get; set; } = "";

        public string Durum { get; set; } = "Bekleniyor";
    }
}
