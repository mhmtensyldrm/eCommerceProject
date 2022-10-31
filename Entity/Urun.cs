using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Entity
{
    public class Urun
    {
        public int Id { get; set; }
        public String Isim { get; set; }
        public String Aciklama { get; set; }
        public double Fiyat { get; set; }
        public int UrunAdet { get; set; }
        public String Resim { get; set; }
        public bool Slider { get; set; }
        public bool AnaSayfada_mi { get; set; }
        public bool Onayli_mi { get; set; }
        public bool OneCikarilmis_mi { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

    }
}