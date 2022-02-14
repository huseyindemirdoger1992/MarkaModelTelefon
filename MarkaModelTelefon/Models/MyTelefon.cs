using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarkaModelTelefon.Models
{
    public class MyTelefon
    {
        [Key]
        public int TelefonId { get; set; }

        [DisplayName("Renk")]
        public int RenkId { get; set; }
        public virtual Renk Renk { get; set; }

        [DisplayName("Gramaj")]
        public double TelefonGRM { get; set; }

        [DisplayName("Telefon MAH")]
        public int TelefonMA { get; set; }
        [DisplayName("Ön Kamera Px")]
        public int TelefonOnKameraPX { get; set; }
        [DisplayName("Arka Kamera Px")]
        public int TelefonOnArkaKameraPX { get; set; }
        [DisplayName("Telefon Garanti Durumu")]
        public bool GarantiDurumu { get; set; }
        [DisplayName("Stok Durumu")]
        public int Adet { get; set; }
        [DisplayName("Model")]
        public int ModelId { get; set; }
        public virtual MyModel MyModel { get; set; }


    }
}