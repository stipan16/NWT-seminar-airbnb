using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seminarNwtAirBnb.Models
{
    public class KorisnikSmjestajnaJedinica
    {
        public int KorisnikSmjestajnaJedinicaID;

        [Range(1, 10)]
        public int Ocjena { get; set; }

      
        public int KorisnikID { get; set; }
      
        [Key]
        public int SmjestajnaJedinicaID { get; set; }
      
    }
}