using ETicaretProje.Entity;
using ETicaretProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretProje.Controllers
{
    public class SiparisController : Controller
    {
        DataContext db = new DataContext();
        [Authorize(Roles ="admin")]
        // GET: Siparis
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i=> new AdminOrderModel() { 
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                ToplamFiyat = i.ToplamFiyat,
                Count = i.OrderLines.Count
            }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                ToplamFiyat = i.ToplamFiyat,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdresBasligi = i.AdresBasligi,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Ilce = i.Ilce,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                Orderlines = i.OrderLines.Select(x => new OrderlineModel()
                {
                    UrunId = x.UrunId,
                    Resim = x.Urun.Resim,
                    UrunIsmi = x.Urun.Isim,
                    Adet = x.Adet,
                    Fiyat = x.Fiyat
                }).ToList()
            }).FirstOrDefault();
            return View(entity);
        }
        public ActionResult UpdateOrderState(int orderId, EnumOrderState orderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == orderId);
            if(order != null)
            {
                order.OrderState = orderState;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgileriniz kaydedildi!";
                return RedirectToAction("Details",new { id=orderId});
            }
            return RedirectToAction("Index");
        }
        public ActionResult BekleyenSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.OnayBekleniyor).ToList();
            return View(orders);
        }
        public ActionResult KargolananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Kargolandı).ToList();
            return View(orders);
        }
        public ActionResult TamamlananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.TeslimEdildi).ToList();
            return View(orders);
        }
        public ActionResult OnaylanmisSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Onaylandı).ToList();
            return View(orders);
        }
    }
}