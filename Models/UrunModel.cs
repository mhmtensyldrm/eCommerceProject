using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Models
{
    public class UrunModel
    {
        public int Id { get; set; }
        public String Isim { get; set; }
        public String Aciklama { get; set; }
        public double Fiyat { get; set; }
        public int UrunAdet { get; set; }
        public String Resim { get; set; }
        public int KategoriId { get; set; }
        
    }
}