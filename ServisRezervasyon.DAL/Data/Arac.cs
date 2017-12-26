using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisRezervasyon.DAL.Data
{
   public class Arac
    {
        [Key]
        public int Id { get; set; }
        public string Plaka { get; set; }
        [Required(ErrorMessage = "Marka boş geçilemez!")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Model boş geçilemez!")]
        public string Model { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Model boş geçilemez!")]
        public DateTime ModelYili { get; set; }
        public string Aciklama { get; set; }
        //Mapping
        public virtual ICollection<Randevu> Randevu { get; set; }

    }
}
