using seminarNwtAirBnb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace seminarNwtAirBnb.DAL
{
    public class ApartmaniContext:DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Iznajmljivac> Iznajmljivaci { get; set; }

        public DbSet<KorisnikSmjestajnaJedinica> KorisnikSmjestajnaJedinica { get; set; }

        public DbSet<SmjestajnaJedinica> SmjestajneJedinice { get; set; }
    }
}