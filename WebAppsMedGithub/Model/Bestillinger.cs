using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bestillinger
    {
        [Key]
        public int BId { get; set; }
        public string Brukernavn { get; set; }
        public int FId { get; set; }
        public DateTime dato { get; set; }
        public virtual List<dbKunder> Kunder { get; set; }
        public virtual List<Filmer> Filmer { get; set; }
    }
}
