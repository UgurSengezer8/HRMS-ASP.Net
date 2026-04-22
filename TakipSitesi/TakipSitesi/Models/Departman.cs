using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TakipSitesi.Models
{
    public class Departman
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string Isim { get; set; }
    }
}
