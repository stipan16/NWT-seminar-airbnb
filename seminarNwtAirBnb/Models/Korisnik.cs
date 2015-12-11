using seminarNwtAirBnb.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seminarNwtAirBnb.Models
{
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public String Ime { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public String Prezime { get; set; }
        [Required]
        [StringLength(160, MinimumLength = 2)]
        public String email { get; set; }

        public byte[] SlikaKorisnika { get; set; }
        public string SlikaSource
        {
            get
            {
                if (SlikaKorisnika == null)
                {
                    return String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(ImageLoader.slika));
                }
                else
                {
                    return String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(SlikaKorisnika));
                }

            }
        }
    }
}