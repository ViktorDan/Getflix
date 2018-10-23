using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    class Kunde
    {
        [Key]
        public string Brukernavn { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Tlf { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
        public virtual Poststeder Poststeder { get; set; }
        public virtual Bestilling Bestillinger { get; set; }
    }
}
