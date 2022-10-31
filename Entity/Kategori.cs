using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Entity
{
    public class Kategori
    {
        public int Id { get; set; }
        public String Isim { get; set; }
        public String Aciklama { get; set; }
        public virtual List<Urun> Urunler{ get; set; }
    }
}