using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    public class Kunde
    {
        // setter navnet vi vil at skal vises for hver atributt i klassen

        // setter at hver atributt er nødvendig å utfylle under registrering

        // lager RegEx for hver atributt for validering under registrering

        [Display(Name = "Brukernavn")]
        [Required(ErrorMessage = "Må oppgi ønsket brukernavn")]
        [RegularExpression (@"[a-zæøåA-ZÆØÅ0-9 ]{2,15}", ErrorMessage = "Feil i brukernavn")]
        public string Brukernavn { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Må oppgi fornavn")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ -]{2,30}", ErrorMessage = "Feil i fornavn")]
        public string Fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Må oppgi etternavn")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ -]{2,15}", ErrorMessage = "Feil i etternavn")]
        public string Etternavn { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Må oppgi adresse")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ0-9 ]{4,20}", ErrorMessage = "Feil i adresse")]
        public string Adresse { get; set; }

        [Display(Name = "Postnummer")]
        [Required(ErrorMessage = "Må oppgi postnummer")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Feil i postnummer")]
        public string Postnr { get; set; }

        [Display(Name = "Poststed")]
        [Required(ErrorMessage = "Må oppgi poststed")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ -]{2,30}", ErrorMessage = "Feil i poststed")]
        public string Poststed { get; set; }

        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Må oppgi telefonnummer")]
        [RegularExpression(@"[0-9]{8}", ErrorMessage = "Feil i Telefonnummer")]
        public string Tlf { get; set; }


        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Må oppgi ønsket passord")]
        [RegularExpression(@"[a-zæøåA-ZÆØÅ0-9]{5,15}", ErrorMessage = "Feil i passord")]
        public string Passord { get; set; }
    }
}