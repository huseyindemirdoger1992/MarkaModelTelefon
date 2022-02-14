using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarkaModelTelefon.Models
{
    public class AppConnectionDbString: DbContext
    {
        public AppConnectionDbString() : base($@"Server=.\SQLEXPRESS;Database=MarkaModelTelefon;User Id = sa; Password=9090;") { }
        public DbSet<MyMarka> MyMarka { get; set; }
        public DbSet<MyModel> MyModel { get; set; }
        public DbSet<MyTelefon> MyTelefon { get; set; }
        public DbSet<Renk> Renk { get; set; }

    }
}