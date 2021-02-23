using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class ClientsDbContext : DbContext
    {
        public DbSet<Klient> Klient { get; set; }

        public DbSet<Zamowienie> Zamowienie { get; set; }

        public DbSet<Pracownik> Pracownik { get; set; }

        public DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }

        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }

        public ClientsDbContext()
        {

        }

        public ClientsDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                        .HasKey(p => new { p.IdWyrobuCukierniczego, p.IdZamowienia });
        }
    }
}
