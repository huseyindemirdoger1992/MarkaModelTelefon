using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarkaModelTelefon.Models
{
    public class MyMarka
    {
        [Key]
        public int MarkaId { get; set; }

        [DisplayName("Marka Adı")]
        public string MarkaAd { get; set; }
        public virtual List<MyModel> MyModel { get; set; }
    }
}