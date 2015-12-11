using seminarNwtAirBnb.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seminarNwtAirBnb.Models
{
    public class SmjestajnaJedinica
    {
        [Key]
        public int SmjestajnaJedinicaID { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public String Naziv { get; set; }

        public String Opis { get; set; }

        public float ProsjecnaOcjena
        {
            get
            {
                int sum = 0, i = 0;
                foreach (KorisnikSmjestajnaJedinica korisnikSmjestajnaJedninica in KorisnikSmjestajneJedinice)
                {
                    sum += korisnikSmjestajnaJedninica.Ocjena;
                    i++;
                }
                return (float)sum / i;
            }
        }
        public virtual ICollection<KorisnikSmjestajnaJedinica> KorisnikSmjestajneJedinice { get; set; }

        public byte[] SlikaSMJ { get; set; }
        public string SlikaSMJSource
        {
            get
            {
                if (SlikaSMJ == null)
                {
                    return String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(ImageLoader.slika));
                }
                else
                {
                    return String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(SlikaSMJ));
                }

            }
        }

        [DisplayName("Komentari")]
        public virtual ICollection<Komentar> Komentari { get; set; }

    }
}