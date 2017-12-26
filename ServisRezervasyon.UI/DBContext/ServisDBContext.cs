using ServisRezervasyon.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServisRezervasyon.UI.DBContext
{
    public class ServisDBContext : DbContext
    {
        public ServisDBContext()
            : base("RezervasyonConnection")

        { }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Arac> Aracs { get; set; }
        public DbSet<Randevu> Randevus { get; set; }

    }
}