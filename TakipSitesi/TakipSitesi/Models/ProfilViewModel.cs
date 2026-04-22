using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakipSitesi.Models
{
    public class ProfilViewModel
    {
        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string EskiSifre { get; set; }
        [Required]
        public string Telefon { get; set; }

        [Required]
        public string Adres { get; set; }
        [Required]
        public IFormFile Resim { get; set; }


    }
}
