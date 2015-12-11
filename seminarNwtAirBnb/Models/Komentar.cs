using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seminarNwtAirBnb.Models
{
    public class Komentar
    {
        [Key]
        public int KomentarId { get; set; }

        public string tekst { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Korisnik KometnarKorisnik { get; set; }
        public virtual SmjestajnaJedinica KometnarSmjestajnaJednica { get; set; }

    }
}