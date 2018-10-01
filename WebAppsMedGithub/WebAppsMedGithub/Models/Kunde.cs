using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    public class Kunde
    {
        public string Brukernavn { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Tlf { get; set; }

        public string Passord { get; set; }

        //public string Etternavn { get; set; }
        //public string Adresse { get; set; }
        //public string Postnr { get; set; }
        //public string Tlf { get; set; }
    }
}