using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTO.Request
{

    public class WyrobDtoRequest
    {
        public int Ilosc { get; set; }

        public string Wyrob { get; set; }

        public string Uwagi { get; set; }
    }


    public class CreateOrderDtoRequest
    {
        public CreateOrderDtoRequest()
        {
            Wyroby = new HashSet<WyrobDtoRequest>();
        }
        public DateTime DataPrzyjecia { get; set; }

        public string Uwagi { get; set; }
       
        public ICollection<WyrobDtoRequest> Wyroby { get; set; }

    }
}
