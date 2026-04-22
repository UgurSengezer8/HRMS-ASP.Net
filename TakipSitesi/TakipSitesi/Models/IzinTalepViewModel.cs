using System.ComponentModel.DataAnnotations;

namespace TakipSitesi.Models
{
    public class IzinTalepViewModel
    {
        [Required(ErrorMessage = "İzin başlangıç tarihi gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime IzinBaslangic { get; set; }

        [Required(ErrorMessage = "İzin bitiş tarihi gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime IzinBitis { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Aciklama { get; set; }
    }
}
