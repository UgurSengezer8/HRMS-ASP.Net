using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakipSitesi.Models;

namespace TakipSitesi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        Db db = new Db();
        public IActionResult AnaSayfa()
        {
            AdminAnasayfaViewModel model = new AdminAnasayfaViewModel();
            model.CalisanSayisi = db.Calisanlar.Where(x=>x.Role=="User").Count().ToString();
            model.DepartmanSayisi=db.Departmanlar.Count().ToString();
            model.BitmisGorevSayisi = db.Gorevler.Where(x => x.Durum == "Teslim Edildi").Count().ToString();
            model.GorevSayisi=db.Gorevler.Count().ToString();
            return View(model);
        }
        public IActionResult Departman()
        {
            
            return View(db.Departmanlar.ToList());
        }
        [HttpPost]
        public IActionResult Departman(string ad)
        {
            if (ad!=null)
            {
                Departman departman = new Departman();
                departman.Isim = ad;
                db.Departmanlar.Add(departman);
                db.SaveChanges();
                TempData["basarili"] = "Departman Oluşturuldu";


            }
            return View(db.Departmanlar.ToList());
        }
        public IActionResult DepartmanSil(string id)
        {
            var departman = db.Departmanlar.FirstOrDefault(x => x.Id.ToString() == id);
            if (departman!=null)
            {
                db.Departmanlar.Remove(departman);
                db.SaveChanges();
            }

            return Redirect("/admin/departman");
        }
        public IActionResult Calisanlar()
        {
            var Calisanlar = db.Calisanlar.Include(c => c.Departman).Where(x=>x.Role=="User").ToList();
            return View(Calisanlar);
        }
        public IActionResult Izinler()
        {
            return View(db.Izinler.Include(x=>x.Kim).ToList());
        }
        public IActionResult IzinDetay(string id)
        {
            var sorgu =db.Izinler.Include(x=>x.Kim).ThenInclude(x => x.Departman).FirstOrDefault(x=>x.Id.ToString() == id);
            if (sorgu==null)
            {
                return Redirect("/admin/anasayfa");
            }

            return View(sorgu);
        }
        [HttpPost]
        public IActionResult IzinDetay(string aciklama,string buton,string id)
        {
            var sorgu = db.Izinler.Include(x => x.Kim).ThenInclude(x=>x.Departman).FirstOrDefault(x => x.Id.ToString() == id);
            if (sorgu == null||aciklama==null||buton==null)
            {
                return Redirect("/admin/anasayfa");
            }
            if (buton=="kabul")
            {
                sorgu.AdminAciklama = aciklama;
                sorgu.Durum = "Onaylandı";
                db.SaveChanges();
                TempData["basarili"] = "İzin Onaylandı";

            }
            if (buton == "red")
            {
                sorgu.AdminAciklama = aciklama;
                sorgu.Durum = "Reddedildi";
                db.SaveChanges();
                TempData["basarili"] = "İzin Reddedildi";

            }
            return Redirect("/admin/Izinler");
        }
        public IActionResult CalisanEkle()
        {
            CalisanEkleViewModel model = new CalisanEkleViewModel();
            model.departmanlar = db.Departmanlar.ToList();
            model.Resim = null;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CalisanEkle(CalisanEkleViewModel calisanekleview)
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                calisanekleview.departmanlar = db.Departmanlar.ToList();
                return View(calisanekleview);
            }
            Calisan calisan = new Calisan();
            calisan.Ad = calisanekleview.calisan.Ad;
            calisan.Adres = calisanekleview.calisan.Adres;
            calisan.Soyad = calisanekleview.calisan.Soyad;
            calisan.IzinDurum = false;
            calisan.KullaniciAdi= calisanekleview.calisan.KullaniciAdi;
            calisan.Sifre = calisanekleview.calisan.Sifre;
            calisan.Yas = calisanekleview.calisan.Yas;
            calisan.DepartmanId = calisanekleview.calisan.DepartmanId;
            calisan.Baslangic = calisanekleview.calisan.Baslangic;
            calisan.Telefon = calisanekleview.calisan.Telefon;
            string yol2 = "";
            var file = calisanekleview.Resim;
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
            calisan.Resim = yol2;
            calisan.Role = calisanekleview.calisan.Role;
            calisan.IzinBaslangic = DateTime.Now;
            calisan.IzinBitis = DateTime.Now;
            TempData["basarili"] = "Çalışan oluşturuldu";

            db.Calisanlar.Add(calisan);
            db.SaveChanges();
            return Redirect("/admin/calisanekle");
        }
        public IActionResult GorevEkle()
        {

            return View(db.Calisanlar.Where(x=>x.Role=="User").ToList());
        }
        public IActionResult Gorevler(string id)
        {
            var gorevler = db.Gorevler.Include(x => x.Kim).ToList();
            if (id=="Biten")
            {
                gorevler = gorevler.Where(x => x.Durum == "Teslim Edildi").ToList();
            }
            return View(gorevler);

        }
        [HttpPost]
        public IActionResult GorevEkle(string calisan,string aciklama,string baslik,string oncelik)
        {
            if (calisan==null|| aciklama == null|| baslik == null||oncelik==null)
            {
                return Redirect("/admin/Gorevekle");

            }
            var aranan =db.Calisanlar.FirstOrDefault(x => x.Id.ToString() == calisan);
            if (aranan==null)
            {
                return Redirect("/admin/Gorevekle");
            }
            Gorev gorev = new Gorev();
            gorev.Aciklama = aciklama;
            gorev.Baslik = baslik;
            gorev.Kim = aranan;
            gorev.Oncelik = oncelik;
            gorev.Durum = "Bekliyor";
            gorev.Detay = "";

            db.Gorevler.Add(gorev);
            db.SaveChanges();
            TempData["basarili"] = "Görev oluşturuldu";

            return View(db.Calisanlar.ToList());
        }
        public IActionResult GorevDetay(string id)
        {
            if (id==null)
            {
                return Redirect("/admin/gorevler");

            }
            var gorev =db.Gorevler.Include(x => x.Kim).FirstOrDefault(x => x.Id.ToString() == id);
            if (gorev==null)
            {
                return Redirect("/admin/gorevler");
            }
            
            return View(gorev);
        }
    }
}
