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
        public bool SlettKunde(String id)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.SlettKunde(id);
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
