using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AdminDAL : DAL.IAdminRepository
    {
        public List<dbKunder> HentAlleKunder()
        {
            using (var db = new DBContext())
            {
                var kunder = db.Kunder.Include(k => k.Poststeder).ToList();
                return kunder;
            }
        }
        public List<Filmer> HentAlleFilmer()
        {
            using (var db = new DBContext())
            {
                var filmer = db.Filmer.ToList();
                return filmer;
            }
        }
        public List<Bestillinger> HentAlleBestillinger()
        {
            using (var db = new DBContext())
            {
                var bestillinger = db.Bestillinger.ToList();
                return bestillinger;
            }
        }
        public bool EndreKunde(int id, String bn, String fn, String en, String ad, String post, String postSted, int tlf)
        {
            var db = new DBContext();
            try
            {
                dbKunder kunde = db.Kunder.Include(k => k.Poststeder).SingleOrDefault(k => k.Id == id);
                kunde.Brukernavn = bn;
                kunde.Fornavn = fn;
                kunde.Etternavn = en;
                kunde.Adresse = ad;
                kunde.Postnr = post;

                var eksistererPostnr = db.Poststeder.Find(post);

                if (eksistererPostnr == null)
                {
                    var nyttPoststed = new Poststeder()
                    {
                        Postnr = post,
                        Poststed = postSted,
                    };
                    kunde.Poststeder = nyttPoststed;
                }

                kunde.Tlf = tlf;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool SlettKunde(int id)
        {
            // denne kalles via et Ajax-kall
            // kunne returnert en feil dersom slettingen feilet....
            var db = new DBContext();
            try
            {
                var slettKunde = db.Kunder.Find(id);
                db.Kunder.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris)
        {
            var db = new DBContext();
            try
            {
                Filmer film = db.Filmer.SingleOrDefault(f => f.FId == id);
                film.Navn = tittel;
                film.Aar = aar;
                film.Sjanger = sjan;
                film.Lengde = len;
                film.Storrelse = stor;
                film.Pris = pris;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SlettFilm(int id)
        {
            // denne kalles via et Ajax-kall
            // kunne returnert en feil dersom slettingen feilet....
            var db = new DBContext();
            try
            {
                var slettFilm = db.Filmer.Find(id);
                db.Filmer.Remove(slettFilm);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool SlettBestilling(int id)
        {
            // denne kalles via et Ajax-kall
            // kunne returnert en feil dersom slettingen feilet....
            var db = new DBContext();
            try
            {
                var slettBestilling = db.Bestillinger.Find(id);
                db.Bestillinger.Remove(slettBestilling);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
    }
}
