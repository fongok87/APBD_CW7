using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Pracownik
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPracownik { get; set; }

        [MaxLength(50)]
        [Required]
        public string Imie { get; set; }

        [MaxLength(60)]
        [Required]
        public string Nazwisko { get; set; }

        public virtual ICollection<Zamowienie> Zamowienia { get; set; }
    }
}
