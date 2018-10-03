using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var poststeder = new List<Poststeder>
            {
            new Poststeder{Postnr="1111",Poststed="Oslo"},
            new Poststeder{Postnr="2222",Poststed="Hamar"},
            new Poststeder{Postnr="3333",Poststed="Tønsberg"},
            new Poststeder{Postnr="4444",Poststed="Trondheim"},
            new Poststeder{Postnr="5555",Poststed="Asker"},
            new Poststeder{Postnr="6666",Poststed="Bærum"},
            new Poststeder{Postnr="7777",Poststed="Fredrikstad"}
            };
            poststeder.ForEach(p => context.Poststeder.Add(p));
            context.SaveChanges();
            var filmer = new List<Filmer>
            {
            new Filmer{FId=1, Navn="Gladiatoren", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde=""},
            new Filmer{FId=2, Navn="Batman", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde=""},
            new Filmer{FId=3, Navn="Avengers", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde=""},
            new Filmer{FId=4, Navn="Lala Land", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde=""},
            new Filmer{FId=5, Navn="We Were Soldiers", Lengde=110, Pris=349, Storrelse=10, Sjanger="Drama", Bilde=""},
            new Filmer{FId=6, Navn="Flukten fra hønsegården", Lengde=110, Pris=349, Storrelse=10, Sjanger="Drama", Bilde=""},
            new Filmer{FId=7, Navn="Troja", Lengde=110, Pris=349, Storrelse=10, Sjanger="Drama", Bilde=""},
            new Filmer{FId=8, Navn="300", Lengde=110, Pris=349, Storrelse=10, Sjanger="Drama", Bilde=""}
            };
            filmer.ForEach(f => context.Filmer.Add(f));
            context.SaveChanges();
        }
    }
}
