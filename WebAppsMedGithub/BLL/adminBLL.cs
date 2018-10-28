using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class AdminBLL
    {
        public List<dbKunder> HentAlleKunder()
        {
            var AdminDAL = new AdminDAL();
            List<dbKunder> kunder = AdminDAL.HentAlleKunder();
            return kunder;
        }
        public List<Filmer> HentAlleFilmer()
        {
            var AdminDAL = new AdminDAL();
            List<Filmer> filmer = AdminDAL.HentAlleFilmer();
            return filmer;
        }

        public List<Bestillinger> HentAlleBestillinger()
        {
            var AdminDAL = new AdminDAL();
            List<Bestillinger> bestillinger = AdminDAL.HentAlleBestillinger();
            return bestillinger;
        }
        public bool EndreKunde(int id, String bl, String fn, String en, String ad, String post, String postSted, int tlf)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.EndreKunde(id, bl, fn, en, ad, post, postSted, tlf);
        }
        public bool SlettKunde(int id)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.SlettKunde(id);
        }
        public bool EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris, String bilde)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.EndreFilm(id, tittel, aar, sjan, len, stor, pris, bilde);
        }
        public bool SlettFilm(int id)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.SlettFilm(id);
        }
        public bool SlettBestilling(int id)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.SlettBestilling(id);
        }
    }
}
