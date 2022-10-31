using ETicaretProje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Models
{
    public class Cart
    {
        private List<Cartline> _cartLines = new List<Cartline>();
        public List<Cartline> Cartlines
        {
            get { return _cartLines; }
        }
        public void UrunEkle(Urun urun, int adet)
        {
            var line = _cartLines.FirstOrDefault(i => i.Urun.Id == urun.Id);
            if(line == null)
            {
                _cartLines.Add(new Cartline() { Urun = urun, Adet=adet });
            }
            else
            {
                line.Adet += adet;
            }
        }
        public void UrunSil(Urun urun)
        {
            _cartLines.RemoveAll(i => i.Urun.Id == urun.Id);
        }
        public double ToplamFiyat()
        {
            return _cartLines.Sum(i => i.Urun.Fiyat * i.Adet);
        }
        public void SepetiTemizle()
        {
            _cartLines.Clear();
        }
    }
    public class Cartline
    {
        public Urun Urun { get; set; }
        public int Adet { get; set; }
    }
}