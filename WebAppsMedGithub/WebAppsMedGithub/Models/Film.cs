using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    // Er ikke sikker på om det er nødvendig med denne klassen. 
    // Kan bare ha en db tabell med filmer som filmsiden henter fra.
    public class Film
    {
        public string navn { get; set; }
        public string sjanger { get; set; }
        public int lengde { get; set; }
        public int storrelse { get; set; }
        public int pris { get; set; }
        public string bilde { get; set; }
    }
}