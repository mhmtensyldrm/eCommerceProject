using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretProje.Entity
{
    public enum EnumOrderState
    {
        [Display(Name ="Siparişin onaylanması bekleniyor.")]
        OnayBekleniyor,
        [Display(Name = "Sipariş teslim edildi.")]
        TeslimEdildi,
        [Display(Name = "Sipariş onaylandı.")]
        Onaylandı,
        [Display(Name = "Sipariş kargolandı.")]
        Kargolandı
    }
}