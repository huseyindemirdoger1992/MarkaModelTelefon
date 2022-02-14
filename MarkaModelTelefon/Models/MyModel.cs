using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarkaModelTelefon.Models
{
    public class MyModel
    {
        [Key]
        public int ModelId { get; set; }

        [DisplayName("Model Adı")]
        public string ModelAd { get; set; }

        [DisplayName("Üretici Marka")]

        public int MarkaId { get; set; }
        public virtual MyMarka MyMarka { get; set; }

        public virtual List<MyTelefon> MyTelefon { get; set; }
    }
}