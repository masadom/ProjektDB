using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBD
{
    public class wypozyczalnia : DbContext
    {

        public wypozyczalnia() : base(@"Server=DESKTOP-QOLSVJC;Database=wypozyczalnia;Integrated Security=True;")
        {
        }

        public DbSet<Klient> Klient { get; set; }
        public DbSet<Samochod> Samochod { get; set; }
        public DbSet<Pracownik> Pracownik { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenie { get; set; }
    }
}
