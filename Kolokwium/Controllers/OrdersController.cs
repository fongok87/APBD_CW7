using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DTO.Request;
using Kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly ClientsDbContext _context;

        public OrdersController(ClientsDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetOrders (string Nazwisko)
        {

            ICollection<Zamowienie> orders;

            if (Nazwisko == null)
            {
                orders = _context.Zamowienie.ToList();
                //...
                return Ok(orders);
            }
            else
            {
                orders = _context.Zamowienie
                            .Where(z => z.Klient.Nazwisko == Nazwisko)

                            .ToList();
            }
            // pobranie dla każdego zamowienia listy wyrobow

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDtoRequest request)
        {
            if (request.Wyroby == null || request.Wyroby.Count == 0)
            {
                return BadRequest("Zamowienie musi miec min 1 wyrob");
            }

            foreach(var i in request.Wyroby)
            {
                if (_context.WyrobCukierniczy.Any(s => s.Nazwa == i.Wyrob))
                {
                    return BadRequest("Podano nieistniejacy wyrob");
                }
            }

            var wyroby = _context.WyrobCukierniczy
                        .Where(w => request.Wyroby.Any(r => r.Wyrob == w.Nazwa));

            var newOrder = new Zamowienie
            {
                DataPrzyjecia = request.DataPrzyjecia,
                Uwagi = request.Uwagi
            };

            var newOrderProduct = request.Wyroby.Select(w => new
            Zamowienie_WyrobCukierniczy
            {
                Ilosc = w.Ilosc,
                Uwagi = w.Uwagi,
                Zamowienie = newOrder,
                WyrobCukierniczy = _context.WyrobCukierniczy.Where(ww => ww.Nazwa == w.Wyrob).First()
            }) ;


            _context.Zamowienie.Add(newOrder);
            //_context.Zamowienie_WyrobCukierniczy.AddRange(newOrderProduct);
            _context.SaveChanges();

            return Ok();
        }
    }
}