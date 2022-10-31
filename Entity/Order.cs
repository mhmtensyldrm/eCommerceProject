using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double ToplamFiyat { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public string UserName { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
        public virtual List<Orderline> OrderLines { get; set; }
    }
    public class Orderline
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Adet { get; set; }
        public double Fiyat { get; set; }
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
    }
}