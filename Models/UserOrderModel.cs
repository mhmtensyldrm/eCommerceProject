using ETicaretProje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double ToplamFiyat { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
}