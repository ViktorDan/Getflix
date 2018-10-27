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

        //}
        public bool SlettKunde(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
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
        public bool SlettFilm(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool SlettBestilling(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
