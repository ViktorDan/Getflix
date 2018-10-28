using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class AdminBLL : IAdminBLL
    {
        private IAdminRepository _Repository;
        public AdminBLL()
        {
            _Repository = new AdminDAL();
        }
        public AdminBLL(IAdminRepository stub)
        {
            _Repository = stub;
        }

        public List<dbKunder> HentAlleKunder()
        {
            List<dbKunder> kunder = _Repository.HentAlleKunder();
            return kunder;
        }
        public List<Filmer> HentAlleFilmer()
        {
            List<Filmer> filmer = _Repository.HentAlleFilmer();
            return filmer;
        }

        public List<Bestillinger> HentAlleBestillinger()
        {
            List<Bestillinger> bestillinger = _Repository.HentAlleBestillinger();
            return bestillinger;
        }
        public bool EndreKunde(int id, String bl, String fn, String en, String ad, String post, String postSted, int tlf)
        {
            var AdminDAL = new AdminDAL();
            return AdminDAL.EndreKunde(id, bl, fn, en, ad, post, postSted, tlf);
        }
        public bool SlettKunde(int id)
        {
            return _Repository.SlettKunde(id);
        }
        public bool EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris, String bilde)
        {
            return _Repository.EndreFilm(id, tittel, aar, sjan, len, stor, pris);
        }
        public bool SlettFilm(int id)
        {
            return _Repository.SlettFilm(id);
        }
        public bool SlettBestilling(int id)
        {
            return _Repository.SlettBestilling(id);
        }
    }
}
