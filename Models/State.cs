using ETicaretProje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Models
{
    public class State
    {
        DataContext db = new DataContext();
        public StateModelStyle GetModelState()
        {
            StateModelStyle models = new StateModelStyle();
            models.OnayBekleyenSayisi = db.Orders.Where(i => i.OrderState == EnumOrderState.OnayBekleniyor).ToList().Count();
            models.KargolananSiparisSayisi = db.Orders.Where(i => i.OrderState == EnumOrderState.Kargolandı).ToList().Count();
            models.TamamlananSiparisSayisi = db.Orders.Where(i => i.OrderState == EnumOrderState.TeslimEdildi).ToList().Count();
            models.OnaylanmisSiparisSayisi = db.Orders.Where(i => i.OrderState == EnumOrderState.Onaylandı).ToList().Count();
            models.UrunSayisi = db.Urunler.Count();
            models.SiparisSayisi = db.Orders.Count();
            return models;
        }
    }
    public class StateModelStyle
    {
        public int UrunSayisi { get; set; }
        public int SiparisSayisi { get; set; }
        public int OnayBekleyenSayisi { get; set; }
        public int KargolananSiparisSayisi { get; set; }
        public int TamamlananSiparisSayisi { get; set; }
        public int OnaylanmisSiparisSayisi { get; set; }
    }
}