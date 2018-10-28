using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    public class Film
    {
        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Må oppgi ønsket Navn")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ0-9 ]{2,15}", ErrorMessage = "Ugyldig Navn")]
        public string Navn { get; set; }

        [Display(Name = "Aar")]
        [Required(ErrorMessage = "Må oppgi ønsket Aar")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Ugyldig")]
        public int Aar { get; set; }

        [Display(Name = "Lengde")]
        [Required(ErrorMessage = "Må oppgi ønsket Lengde")]
        [RegularExpression(@"[0-9 ]{1,3}", ErrorMessage = "Ugyldig")]
        public int Lengde { get; set; }

        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Må oppgi ønsket Pris")]
        [RegularExpression(@"[0-9 ]{1,4}", ErrorMessage = "Ugyldig")]
        public int Pris { get; set; }

        [Display(Name = "Størrelse")]
        [Required(ErrorMessage = "Må oppgi ønsket Størrelse")]
        [RegularExpression(@"[0-9 ]{1,3}", ErrorMessage = "Ugyldig")]
        public int Str { get; set; }

        [Display(Name = "Sjanger")]
        [Required(ErrorMessage = "Må oppgi ønsket Sjanger")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ0-9 ]{2,15}", ErrorMessage = "Ugyldig")]
        public string Sjanger { get; set; }

        [Display(Name = "Bilde")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ0-9 .]{2,15}", ErrorMessage = "Ugyldig")]
        public string Bilde { get; set; }
    }
}