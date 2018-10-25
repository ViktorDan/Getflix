using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AdminDAL
    {
        public List<dbKunder> HentAlleKunder()
        {
            using (var db = new DBContext())
            {
                var kunder = db.Kunder.ToList();
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
        public bool SlettKunde(String id)
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
