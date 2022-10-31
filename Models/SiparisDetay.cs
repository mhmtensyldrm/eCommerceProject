using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretProje.Models
{
    public class SiparisDetay
    {
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen adres tanımını giriniz!")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen adresinizi giriniz!")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen yaşadığınız şehri giriniz!")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen yaşadığınız ilçeyi giriniz!")]
        public string Ilce { get; set; }

        [Required(ErrorMessage = "Lütfen yaşadığınız mahalleyi giriniz!")]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
    }
}