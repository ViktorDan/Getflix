using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public interface IAdminBLL
    {
        List<dbKunder> HentAlleKunder();
        List<Filmer> HentAlleFilmer();
        List<Bestillinger> HentAlleBestillinger();
        bool EndreKunde(int id, String bl, String fn, String en, String ad, String post, String postSted, int tlf);
        bool SlettKunde(int id);
        bool EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris);
        bool SlettFilm(int id);
        bool SlettBestilling(int id);
    }
}
