using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    class Bestilling
    {
        [Key]
        public int BId { get; set; }
        public string Brukernavn { get; set; }
        public int FId { get; set; }
        public virtual List<Kunde> Kunder { get; set; }
        public virtual List<Film> Filmer { get; set; }
    }
}
