using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TakipSitesi.Models
{
    public class CalisanEkleViewModel
    {
        public Calisan calisan { get; set; }
        [ValidateNever]
        public List<Departman> departmanlar { get; set; } = null;
        [Required(ErrorMessage = "Resim alanı zorunludur.")]
        public IFormFile Resim { get; set; }
    }
}
