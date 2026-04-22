using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakipSitesi.Models;

namespace TakipSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        Db db = new Db();
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var calisan = db.Calisanlar.Include(c => c.Departman).FirstOrDefault(c => c.Id == int.Parse(userId));
            return View(calisan);
        }
        [Authorize(Roles ="User")]
        public IActionResult gonder()
        {
            Departman departmandeneme = new Departman();
            departmandeneme.Isim = "deneme›sim";
            db.Departmanlar.Add(departmandeneme);
            db.SaveChanges();
            return Redirect("/home/Index");
        }


        public IActionResult Privacy()
        {
            
            return View();
        }
        [HttpGet]
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
