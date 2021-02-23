using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTO.Response
{
    public class OrderDtoResponse
    {

        public int IdZamowienia { get; set; }

        public DateTime DataPrzyjecia { get; set; }

        public DateTime? DataRealizacji { get; set; }

        public string? Uwagi { get; set; }

        public ICollection<WyrobCukierniczy> WyrobCukierniczy { get; set; }
    }
}
