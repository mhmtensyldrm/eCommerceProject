using ETicaretProje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Models
{
    public class Bildirim
    {
        DataContext db = new DataContext();
        public List<Order> SiparisBekleyenListe()
        {
            return db.Orders.Where(i => i.OrderState == EnumOrderState.OnayBekleniyor).ToList();
        }
    }
}