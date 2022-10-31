using ETicaretProje.Entity;
using ETicaretProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretProje.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var urun = db.Urunler.FirstOrDefault(i => i.Id == Id);
            if(urun != null)
            {
                GetCart().UrunEkle(urun, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var urun = db.Urunler.FirstOrDefault(i => i.Id == Id);
            if (urun != null)
            {
                GetCart().UrunSil(urun);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(new SiparisDetay());
        }   
        [HttpPost]
        public ActionResult Checkout(SiparisDetay entity)
        {
            var cart = GetCart();
            if (cart.Cartlines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır!");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.SepetiTemizle();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }

        private void SaveOrder(Cart cart, SiparisDetay entity)
        {
            var order = new Order();
            order.OrderNumber = "S" + (new Random()).Next(1111, 9999).ToString();
            order.ToplamFiyat = cart.ToplamFiyat();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.OnayBekleniyor;
            order.UserName = User.Identity.Name;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Ilce = entity.Ilce;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<Orderline>();
            foreach (var pr in cart.Cartlines)
            {
                var orderline = new Orderline();
                orderline.Adet = pr.Adet;
                orderline.Fiyat = pr.Adet * pr.Urun.Fiyat;
                orderline.UrunId = pr.Urun.Id;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}