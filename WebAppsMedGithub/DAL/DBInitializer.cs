using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace DAL
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var poststeder = new List<Poststeder>
            {
            new Poststeder{Postnr=1111,Poststed="Oslo"},
            new Poststeder{Postnr=2222,Poststed="Hamar"},
            new Poststeder{Postnr=3333,Poststed="Tønsberg"},
            new Poststeder{Postnr=4444,Poststed="Trondheim"},
            new Poststeder{Postnr=5555,Poststed="Asker"},
            new Poststeder{Postnr=6666,Poststed="Bærum"},
            new Poststeder{Postnr=7777,Poststed="Fredrikstad"}
            };
            poststeder.ForEach(p => context.Poststeder.Add(p));
            context.SaveChanges();

            var filmer = new List<Filmer>
            {
            new Filmer{FId=1, Navn="Gladiatoren", Aar=2000, Lengde=155, Pris=49, Storrelse=10, Sjanger="Action", Bilde= "../Bilder/Gladiator.jpg"},
            new Filmer{FId=2, Navn="Suicide Squad", Aar=2016, Lengde=123, Pris=49, Storrelse=10, Sjanger="Action", Bilde="../Bilder/SuicideSquad.jpg"},
            new Filmer{FId=3, Navn="Avengers", Aar=2012, Lengde=143, Pris=49, Storrelse=10, Sjanger="Action", Bilde="../Bilder/Avengers.jpg"},
            new Filmer{FId=4, Navn="Elysium", Aar=2013, Lengde=109, Pris=49, Storrelse=10, Sjanger="SiFi", Bilde="../Bilder/Elysium.jpg"},
            new Filmer{FId=5, Navn="Fight Club", Aar=1999, Lengde=139, Pris=49, Storrelse=10, Sjanger="Drama", Bilde="../Bilder/FightClub.jpg"},
            new Filmer{FId=6, Navn="Saving Private Ryan", Aar=1998, Lengde=169, Pris=49, Storrelse=10, Sjanger="Drama", Bilde="../Bilder/SavingPrivateRyan.jpg"},
            new Filmer{FId=7, Navn="Batman Begins", Aar=2005, Lengde=140, Pris=49, Storrelse=10, Sjanger="Action", Bilde="../Bilder/BatmanBegins.jpg"},
            new Filmer{FId=8, Navn="The Dark Knight", Aar=2008, Lengde=152, Pris=49, Storrelse=10, Sjanger="Action", Bilde="../Bilder/DarkKnight.jpg"},
            new Filmer{FId=9, Navn="The Dark Knight Rises", Aar=2012, Lengde=164, Pris=49, Storrelse=10, Sjanger="Action", Bilde="../Bilder/DarkKnightRises.jpg"},
            new Filmer{FId=10, Navn="22 Jump Street", Aar=2014, Lengde=112, Pris=49, Storrelse=10, Sjanger="Komedie", Bilde="../Bilder/22JumpStreet.jpg"},
            new Filmer{FId=11, Navn="Looper", Aar=2012, Lengde=113, Pris=49, Storrelse=10, Sjanger="SiFi", Bilde="../Bilder/Looper.jpg"},
            new Filmer{FId=12, Navn="Blade Runner", Aar=1982, Lengde=117, Pris=49, Storrelse=10, Sjanger="SiFi", Bilde="../Bilder/BladeRunner.jpg"},
            new Filmer{FId=13, Navn="Inception", Aar=2010, Lengde=148, Pris=49, Storrelse=10, Sjanger="Thriller", Bilde="../Bilder/Inception.jpg"},
            new Filmer{FId=14, Navn="Shutter Island", Aar=2010, Lengde=138, Pris=49, Storrelse=10, Sjanger="Thriller", Bilde="../Bilder/ShutterIsland.jpg"},
            new Filmer{FId=15, Navn="Django Unchained", Aar=2012, Lengde=165, Pris=49, Storrelse=10, Sjanger="Western", Bilde="../Bilder/DjangoUnchained.jpg"}
            };
            filmer.ForEach(f => context.Filmer.Add(f));
            context.SaveChanges();
        }
    }
}
