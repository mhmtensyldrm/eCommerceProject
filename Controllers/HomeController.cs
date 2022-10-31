using ETicaretProje.Entity;
using ETicaretProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretProje.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        
        public ActionResult Index()
        {
            var urun = db.Urunler.Where(i => i.AnaSayfada_mi && i.Onayli_mi).Select(i => new UrunModel()
            {
                Id = i.Id,
                Isim = i.Isim,
                Aciklama = i.Aciklama.Length > 25 ? i.Aciklama.Substring(0, 20) + "..." : i.Aciklama,
                Fiyat = i.Fiyat,
                UrunAdet = i.UrunAdet,
                Resim = i.Resim,
                KategoriId = i.KategoriId
            }).ToList();
            return View(urun);
        }
        public PartialViewResult _Slider()
        {
            return PartialView(db.Urunler.Where(x => x.Slider && x.Onayli_mi).Take(3).ToList());
        }
        public PartialViewResult PopulerUrunList()
        {
            return PartialView(db.Urunler.Where(x=>x.Onayli_mi && x.OneCikarilmis_mi).Take(5).ToList());
        }
        public ActionResult UrunList(int id)
        {
            return View(db.Urunler.Where(i => i.KategoriId == id).ToList());
        }
        public ActionResult ProductDetails(int id)
        {
            return View(db.Urunler.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult Arama(string text)
        {
            var p = db.Urunler.Where(i => i.Onayli_mi == true);
            if (!string.IsNullOrEmpty(text))
            {
                p = p.Where(i => i.Isim.Contains(text) || i.Aciklama.Contains(text));
            }
            return View(p.ToList());
        }
        public ActionResult Product()
        {
            var urun = db.Urunler.Where(i =>i.Onayli_mi).Select(i => new UrunModel()
            {
                Id = i.Id,
                Isim = i.Isim,
                Aciklama = i.Aciklama.Length > 25 ? i.Aciklama.Substring(0, 20) + "..." : i.Aciklama,
                Fiyat = i.Fiyat,
                UrunAdet = i.UrunAdet,
                Resim = i.Resim,
                KategoriId = i.KategoriId
            }).ToList();
            return View(urun);
        }
    }
}