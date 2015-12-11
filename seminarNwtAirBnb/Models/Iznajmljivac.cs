using seminarNwtAirBnb.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace seminarNwtAirBnb.Models
{
    public class Iznajmljivac
    {
        [Key]
        public int IznajmljivacID { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public String Ime { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public String Prezime { get; set; }

        [DisplayName("ListaSmjestajnihJedinica")]
        public virtual ICollection<SmjestajnaJedinica> ListaSmjestajnihJedinica { get; set; }

        public byte[] SlikaIznajmljivac { get; set; }
        public string SlikaIznajmSource
        {
            get
            {
                if (SlikaIznajmljivac == null)
                {
                    return String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(ImageLoader.slika));
                }
                else
                {
                    return String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(SlikaIznajmljivac));
                }

            }
        }
    }
}