using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarkaModelTelefon.Models
{
    public class Renk
    {
        [Key]
        public int RenkId { get; set; }

        [DisplayName("Renk Adı")]
        public string RenkAd { get; set; }

        public virtual List<MyTelefon> MyTelefons { get; set; }
    }
}