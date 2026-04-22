using System.ComponentModel.DataAnnotations;

namespace TakipSitesi.Models
{
    public class LoginViewModel
    {
        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}
