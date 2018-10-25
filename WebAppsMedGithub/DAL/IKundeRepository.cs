using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppsMedGit.Model;

namespace WebAppsMedGit.DAL
{
    public interface IKundeRepository
    {
        bool endreKunde(int id,  dbKunder innKunde);
    }
}
