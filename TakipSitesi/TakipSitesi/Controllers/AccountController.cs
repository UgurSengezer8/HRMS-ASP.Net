using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TakipSitesi.Models;
using Microsoft.AspNetCore.Authorization;
using static System.Net.Mime.MediaTypeNames;

namespace TakipSitesi.Controllers
{
    
    public class AccountController : Controller
    {
        Db db = new Db();

        // GET: Account
        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Giris(LoginViewModel model)
        {
            if (!ModelState.IsValid!)
            {
                return View(model);
            }
            var kullanici = db.Calisanlar.FirstOrDefault(n => n.KullaniciAdi == model.KullaniciAdi && n.Sifre == model.Sifre);
            if (kullanici != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,kullanici.KullaniciAdi),
                    new Claim(ClaimTypes.NameIdentifier,kullanici.Id.ToString()),

                    new Claim(ClaimTypes.Role,kullanici.Role)
                };
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false // Oturum kalıcı
                };
                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);


                HttpContext.Session.SetString("username", kullanici.KullaniciAdi);
                HttpContext.Session.SetString("userid", kullanici.Id.ToString());
                ViewBag.username = HttpContext.Session.GetString("username");
                if (kullanici.Role=="Admin")
                {
                    return Redirect("/Admin/anasayfa");

                }
                return Redirect("/home");
            }
            ModelState.AddModelError(string.Empty, "Şifre yada kullanıcı adı hatalı");

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Goster()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult GorevDetay(string id)
        {
            var gorev =db.Gorevler.FirstOrDefault(x => x.Id.ToString() == id);
            if (gorev==null)
            {
                return Redirect("/home");
            }
            
            return View(gorev);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult GorevDetay(string id,string Durum,string EkAciklama)
        {
            if (id==null||Durum==null||EkAciklama==null)
            {
                return Redirect("/account/gorevlerim");
            }
            var gorev = db.Gorevler.FirstOrDefault(x => x.Id.ToString() == id);
            if (gorev == null)
            {
                return Redirect("/home");
            }
            gorev.Durum = Durum;
            gorev.CalisanAciklama = EkAciklama;
            TempData["basarili"] = "Gorev detayı gönderildi";

            db.SaveChanges();
            return Redirect("/account/gorevlerim");
        }

        [Authorize]
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("userid", "");

            //
            return Redirect("/account/giris");

        }
        [Authorize(Roles = "User")]
        public IActionResult Profil()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var calisan = db.Calisanlar.FirstOrDefault(c => c.Id == int.Parse(userId));
            
            if (calisan == null)
            {
                return NotFound("Çalışan bulunamadı.");
            }
            ProfilViewModel profilview = new ProfilViewModel();
            
            profilview.Sifre = calisan.Sifre;
            profilview.KullaniciAdi = calisan.KullaniciAdi;
            profilview.Adres=calisan.Adres;
            profilview.Telefon = calisan.Telefon;
            profilview.Resim = null;

            return View(profilview);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Profil(ProfilViewModel profil)
        {
            if (!ModelState.IsValid)
            {
                return View(profil);
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var calisan = db.Calisanlar.FirstOrDefault(c => c.Id == int.Parse(userId));

            if (calisan == null)
            {
                TempData["hata"] = "Calisan Bulamadik";
                return View(profil);

            }
            if (profil.EskiSifre !=calisan.Sifre)
            {
                TempData["hata"] = "eski sifren hatali";
                return View(profil);
            }
            string yol2 = "";
            var file = profil.Resim;
            if (file.Length > 0)
            {
                string yol1 = "/wwwroot/upload/" + file.FileName;
                yol2 = "/upload/" + file.FileName;

                string uploadpath = Path.Combine(Directory.GetCurrentDirectory());
                uploadpath = uploadpath + yol1;
                using (var stream = new FileStream(uploadpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            
            calisan.KullaniciAdi = profil.KullaniciAdi;
            calisan.Adres = profil.Adres;
            calisan.Sifre = profil.Sifre;
            calisan.Telefon = profil.Telefon;
            calisan.Resim = yol2;
            db.SaveChanges();
            TempData["basarili"] = "Basariyla Bilgilerinizi Guncellediniz";

            return View(profil);
        }
        [Authorize(Roles = "User")]
        public IActionResult Talepler()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var calisan = db.Calisanlar.FirstOrDefault(c => c.Id == int.Parse(userId));
            if (calisan == null)
            {
                return View();
            }
            var talepler = db.Izinler.Where(x => x.Kim.Id.ToString() == calisan.Id.ToString()).ToList();

            return View(talepler);
        }
        [Authorize(Roles = "User")]
        public IActionResult IzinDetay(string id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var calisan = db.Calisanlar.FirstOrDefault(c => c.Id == int.Parse(userId));
            var Izin = db.Izinler.FirstOrDefault(x => x.Id.ToString() == id&&x.Kim.Id.ToString() == calisan.Id.ToString());
            if (Izin == null) 
            {
                return RedirectToAction("Talepler");
            }

            return View(Izin);
        }
        [Authorize(Roles = "User")]
        public IActionResult IzinTalep()
        {
            var talep = new IzinTalepViewModel();
            talep.IzinBaslangic = DateTime.Now;
            talep.IzinBitis = DateTime.Now;
            return View(talep);
        }

        [HttpPost]
        public IActionResult IzinTalep(IzinTalepViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.IzinBitis<=model.IzinBaslangic)
            {
                // burda izini aynı gün e yada önceki günlere almanı engelliyor
                // ve izin bitiş tarihinin başlangıçtan ileride olması gerekiyor
                TempData["uyari"] = "Başlangıç Tarihi Bitiş Tarihinden ileride yada eşit olamaz";

                return View(model);
            }
            if (model.IzinBaslangic<DateTime.Now && model.IzinBitis<DateTime.Now)
            {
                TempData["uyari"] = "Baslangiç veya Bitiş Tarihi Günümüzden ileride olmalı";

                return View(model);


            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var calisan = db.Calisanlar.FirstOrDefault(c => c.Id == int.Parse(userId));
            if(calisan == null)
            {
                return View(model);
            }
            Izin izin = new Izin();
            izin.Baslangic = model.IzinBaslangic;
            izin.Bitis = model.IzinBitis;
            izin.Aciklama = model.Aciklama;
            izin.Kim = calisan;
            izin.KimId = calisan.Id.ToString();
            db.Izinler.Add(izin);
            db.SaveChanges();
            // Burada veritabanına kayıt işlemi yapılabilir
            // Örneğin ilgili çalışanın izin bilgileri güncellenebilir

            TempData["basarili"] = "İzin talebiniz alındı.";
            return Redirect("/account/talepler"); // ya da başka bir sayfa
        }
        [Authorize(Roles = "User")]
        public IActionResult Gorevlerim()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var calisan = db.Calisanlar.FirstOrDefault(c => c.Id == int.Parse(userId));
            if (calisan==null)
            {
                return Redirect("/home");
            }
            var gorevlerim = db.Gorevler.Where(x => x.KimId == calisan.Id).ToList();
            return View(gorevlerim);
        }
    }
}
