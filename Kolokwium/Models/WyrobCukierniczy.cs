using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class WyrobCukierniczy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWyrobuCukierniczego { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nazwa { get; set; }

        public float CenaZaSzt { get; set; }

        [MaxLength(40)]
        [Required]
        public string Typ { get; set; }

        public virtual ICollection<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }

    }
}
