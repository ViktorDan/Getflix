using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppsMedGithub.Models;

namespace WebAppsMedGithub
{
    public class DBFunksjonalitet
    {
        public List<Film> alleFilmer()
        {
            using (var db = new DBContext())
            {
                List<Film> alleFilmer = db.Filmer.Select(f => new Film
                {
                    fid = f.FId,
                    navn = f.Navn,
                    lengde = f.Lengde,
                    storrelse = f.Storrelse,
                    pris = f.Pris
                }).ToList();

                return alleFilmer;
            }
        }

        public bool lagreFilm(Film innFilm)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var nyFilmRad = new Filmer();
                    nyFilmRad.Navn = innFilm.navn;
                    nyFilmRad.Lengde = innFilm.lengde;
                    nyFilmRad.Storrelse = innFilm.storrelse;
                    nyFilmRad.Pris = innFilm.pris;

                    db.Filmer.Add(nyFilmRad);
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
}