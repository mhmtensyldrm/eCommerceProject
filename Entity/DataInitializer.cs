using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretProje.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Kategori>() 
            {
                new Kategori() {Isim="KAMERA",Aciklama="Kamera Ürünleri" },
                new Kategori() {Isim="BİLGİSAYAR",Aciklama="Bilgisayar Ürünleri" }
            };
            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();

            var urunler = new List<Urun>()
            {
                new Urun() {Isim="Canon", Aciklama="Kamera",Fiyat=8000,UrunAdet=40,AnaSayfada_mi=true,KategoriId=1,Resim="kamera1.jpg",Onayli_mi=true,OneCikarilmis_mi=false },
                new Urun() {Isim="Asus Bilgisayar", Aciklama="Asus Bilgisayar Ürünleri",Fiyat=7000,UrunAdet=25,AnaSayfada_mi=false,KategoriId=2,Resim="pc1.jpg",Onayli_mi=true,OneCikarilmis_mi=true },
                new Urun() {Isim="Casper Bilgisayar", Aciklama="Casper Bilgisayar Ürünleri",Fiyat=6000,UrunAdet=30,AnaSayfada_mi=true,KategoriId=2,Resim="pc2.jpg",Onayli_mi=true,OneCikarilmis_mi=false }
            };
            foreach (var item in urunler)
            {
                context.Urunler.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}