using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    public class Kunde
    {
        [Key]
        public int kid { get; set; }

        [Display (Name = "Fornavn")]
        [Required (ErrorMessage = "Fornavn må oppgis")]
        [RegularExpression (@"[a-zæøåAZÆØÅ ]{2,30}", ErrorMessage = "Fornavn må være mellom 2 og 30 bokstaver")]
        public string fornavn { get; set; }

        [Display (Name = "Etternavn")]
        [Required (ErrorMessage = "Etternavn må oppgis")]
        [RegularExpression (@"[a-zæøåA-ZÆØÅ]{2,15}", ErrorMessage = "Etternavn må være mellom 2 og 15 bokstaver")]
        public string etternavn { get; set; }

        [Display (Name = "Adresse")]
        [Required (ErrorMessage = "Adresse må oppgis")]
        [RegularExpression (@"[a-zæøåA-ZÆØÅ0-9]{4,30}", ErrorMessage = "Adresse må være mellom 4 og 30 bakstaver og tall")]
        public string adresse { get; set; }

        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        [RegularExpression(@"[0-9]{8}", ErrorMessage = "Telefonnummer må være på 8 siffer")]
        public string tlf { get; set; }
    }
}