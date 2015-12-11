using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using seminarNwtAirBnb.Models;
using System.Drawing;

namespace seminarNwtAirBnb.DAL
{
    public class ApartmaniInitaializer : DropCreateDatabaseAlways<ApartmaniContext>
    {
        protected override void Seed(ApartmaniContext context)
        {
            string slikeDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\Resources";

            var korisnici = new List<Korisnik>()
            {
                new Korisnik() { Ime="Stipan",Prezime="Stipic",email="nesto@gmiail.com",SlikaKorisnika= (Image.FromFile(slikeDirectory + @"\user1.png")).toByteArray() },
                new Korisnik() { Ime="Boban",Prezime="Rajovic",email="boban@gmiail.com",SlikaKorisnika= (Image.FromFile(slikeDirectory + @"\user2.png")).toByteArray()}
            };
            korisnici.ForEach(korisnik => context.Korisnici.Add(korisnik));

            var iznajmljivaci = new List<Iznajmljivac>()
            {
                new Iznajmljivac() { Ime="Antun",Prezime="Tun",SlikaIznajmljivac= (Image.FromFile(slikeDirectory + @"\user2.png")).toByteArray()},
                new Iznajmljivac() { Ime="Milan",Prezime="Stankovic",SlikaIznajmljivac= (Image.FromFile(slikeDirectory + @"\user3.png")).toByteArray()}
            };

            iznajmljivaci.ForEach(iznajmljivac => context.Iznajmljivaci.Add(iznajmljivac));

            var listaKomentara = new List<Komentar>()
            {
                new Komentar() { tekst="ova kuca je super",DateTime=DateTime.Now,KometnarKorisnik=korisnici[0] },
                new Komentar() { tekst = "Najbolji odmor ikada", DateTime = DateTime.Now,KometnarKorisnik=korisnici[1] },
                new Komentar() { tekst = "Vidimo se i dogodine", DateTime = DateTime.Now,KometnarKorisnik=korisnici[0] }
            };

            var listaSJ = new List<SmjestajnaJedinica>()
            {
                new SmjestajnaJedinica() { Naziv="CDT290",Opis="Uz more", SlikaSMJ= (Image.FromFile(slikeDirectory + @"\kuca1.jpg")).toByteArray()},
                new SmjestajnaJedinica() { Naziv="CDT200",Opis="seosko imanje",SlikaSMJ= (Image.FromFile(slikeDirectory + @"\seoskoImanje.jpg")).toByteArray()},
                new SmjestajnaJedinica() { Naziv="CDT550",Opis="50 m od mora",SlikaSMJ= (Image.FromFile(slikeDirectory + @"\kuca2.jpg")).toByteArray()}
            };
            
            listaSJ[0].Komentari = new List<Komentar>() { listaKomentara[0] };
            listaSJ[1].Komentari = new List<Komentar>() { listaKomentara[1],listaKomentara[2] };

            listaSJ.ForEach(smjestajnaJedinica => context.SmjestajneJedinice.Add(smjestajnaJedinica));

            iznajmljivaci[0].ListaSmjestajnihJedinica = new List<SmjestajnaJedinica>() { listaSJ[0],listaSJ[2] };
            iznajmljivaci[1].ListaSmjestajnihJedinica = new List<SmjestajnaJedinica>() { listaSJ[1] };

            iznajmljivaci.ForEach(iznajmljivac => context.Iznajmljivaci.Add(iznajmljivac));

            context.SaveChanges();
        }
    }
}