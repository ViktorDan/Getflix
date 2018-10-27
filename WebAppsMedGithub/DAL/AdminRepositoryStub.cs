using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AdminRepositoryStub : IAdminRepository
    {
        public List<dbKunder> HentAlleKunder()
        {
            var KundeListe = new List<dbKunder>();
            var kunde = new dbKunder()
            {
                Id = 1,
                Fornavn = "Henrik",
                Etternavn = "Karlsen",
                Adresse = "Kirkeveien 11",
                Postnr = 1234,
                Tlf = 12345678,
            };
            KundeListe.Add(kunde);
            KundeListe.Add(kunde);
            KundeListe.Add(kunde);
            return KundeListe;
        }

        public List<Filmer> HentAlleFilmer()
        {
            var FilmListe = new List<Filmer>();
            var film = new Filmer()
            {
                FId = 1,
                Navn = "IT",
                Aar = 2017,
                Lengde = 110,
                Pris = 160,
                Sjanger = "Skrekk",
                Bilde = "IT.jpg",
            };
            FilmListe.Add(film);
            FilmListe.Add(film);
            FilmListe.Add(film);
            return FilmListe;
        }

        public List<Bestillinger> HentAlleBestillinger()
        {
            var BestillListe = new List<Bestillinger>();
            var bestilling = new Bestillinger()
            {
                BId = 1,
                Brukernavn = "Bruker1",
                FId = 1,
                dato = DateTime.Today,
            };
            BestillListe.Add(bestilling);
            BestillListe.Add(bestilling);
            BestillListe.Add(bestilling);
            return BestillListe;
        }

        public bool EndreKunde(int id, String bn, String fn, String en, String ad, int post, int tlf)
        {
            if (id==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public bool SlettKunde(int id)
        //{
        //    // denne kalles via et Ajax-kall
        //    // kunne returnert en feil dersom slettingen feilet....
        //    var db = new DBContext();
        //    try
        //    {
        //        var slettKunde = db.Kunder.Find(id);
        //        db.Kunder.Remove(slettKunde);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception feil)
        //    {
        //        return false;
        //    }
        //}
        //public bool EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris)
        //{
        //    var db = new DBContext();
        //    try
        //    {
        //        Filmer film = db.Filmer.SingleOrDefault(f => f.FId == id);
        //        film.Navn = tittel;
        //        film.Aar = aar;
        //        film.Sjanger = sjan;
        //        film.Lengde = len;
        //        film.Storrelse = stor;
        //        film.Pris = pris;
        //        db.SaveChanges();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool SlettFilm(int id)
        //{
        //    // denne kalles via et Ajax-kall
        //    // kunne returnert en feil dersom slettingen feilet....
        //    var db = new DBContext();
        //    try
        //    {
        //        var slettFilm = db.Filmer.Find(id);
        //        db.Filmer.Remove(slettFilm);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception feil)
        //    {
        //        return false;
        //    }
        //}
        //public bool SlettBestilling(int id)
        //{
        //    // denne kalles via et Ajax-kall
        //    // kunne returnert en feil dersom slettingen feilet....
        //    var db = new DBContext();
        //    try
        //    {
        //        var slettBestilling = db.Bestillinger.Find(id);
        //        db.Bestillinger.Remove(slettBestilling);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception feil)
        //    {
        //        return false;
        //    }
    }
}
