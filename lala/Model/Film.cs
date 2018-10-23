using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    class Film
    {
        [Key]
        public int FId { get; set; }
        public string Navn { get; set; }
        public int Aar { get; set; }
        public int Lengde { get; set; }
        public int Storrelse { get; set; }
        public int Pris { get; set; }
        public string Sjanger { get; set; }
        public string Bilde { get; set; }
        public virtual Bestilling Bestillinger { get; set; }
    }
}
