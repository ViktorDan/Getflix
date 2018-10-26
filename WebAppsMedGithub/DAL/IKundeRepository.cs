using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppsMedGithub.Model;

namespace WebAppsMedGithub.DAL
{
    public interface IKundeRepository
    {
        bool endreKunde(int id,  Kunde innKunde);
    }
}
