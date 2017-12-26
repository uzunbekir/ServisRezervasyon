using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisRezervasyon.DAL.Data
{
   public class Musteri
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Adı")]
        [Required(ErrorMessage ="Adı boş geçilemez!")]
        public string Ad { get; set; }
        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "Soyadı boş geçilemez!")]
        public string Soyad { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon Numarası boş geçilemez!")]
        public string Telefon { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Randevu> Randevu { get; set; }
    }
}
