using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisRezervasyon.DAL.Data
{
   
   public class Randevu
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }
        public bool OnaylandıMı { get; set; }
        public int ?AracId { get; set; }
        public int ?MusteriId { get; set; }
        //Mapping
        [ForeignKey("AracId")]
        public virtual Arac Arac { get; set; }
        [ForeignKey("MusteriId")]
        public virtual Musteri Musteri { get; set; }
    }
}
