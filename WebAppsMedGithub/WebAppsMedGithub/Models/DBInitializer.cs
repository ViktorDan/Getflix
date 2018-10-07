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
            new Filmer{FId=1, Navn="Gladiatoren", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde= "../Bilder/Gladiator.jpg"},
            new Filmer{FId=2, Navn="Suicide Squad", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde="../Bilder/SuicideSquad.jpg"},
            new Filmer{FId=3, Navn="Avengers", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde="../Bilder/Avengers.jpg"},
            new Filmer{FId=4, Navn="Elysium", Lengde=110, Pris=349, Storrelse=10, Sjanger="SiFi", Bilde="../Bilder/Elysium.jpg"},
            new Filmer{FId=5, Navn="Fight Club", Lengde=110, Pris=349, Storrelse=10, Sjanger="Drama", Bilde="../Bilder/FightClub.jpg"},
            new Filmer{FId=6, Navn="Saving Private Ryan", Lengde=110, Pris=349, Storrelse=10, Sjanger="Drama", Bilde="../Bilder/SavingPrivateRyan.jpg"},
            new Filmer{FId=7, Navn="Batman Begins", Lengde=110, Pris=349, Storrelse=10, Sjanger="Action", Bilde="../Bilder/BatmanBegins.jpg"},
            new Filmer{FId=8, Navn="The Dark Knight", Lengde=152, Pris=349, Storrelse=10, Sjanger="Action", Bilde="../Bilder/DarkKnight.jpg"},
            new Filmer{FId=9, Navn="The Dark Knight Rises", Lengde=100, Pris=349, Storrelse=10, Sjanger="Action", Bilde="../Bilder/DarkKnightRises.jpg"},
            new Filmer{FId=10, Navn="22 Jump Street", Lengde=92, Pris=349, Storrelse=10, Sjanger="Komedie", Bilde="../Bilder/22JumpStreet.jpg"},
            new Filmer{FId=11, Navn="Looper", Lengde=162, Pris=349, Storrelse=10, Sjanger="SiFi", Bilde="../Bilder/Looper.jpg"},
            new Filmer{FId=12, Navn="Blade Runner", Lengde=134, Pris=349, Storrelse=10, Sjanger="SiFi", Bilde="../Bilder/BladeRunner.jpg"},
            new Filmer{FId=13, Navn="Inception", Lengde=148, Pris=349, Storrelse=10, Sjanger="Thriller", Bilde="../Bilder/Inception.jpg"},
            new Filmer{FId=14, Navn="Shutter Island", Lengde=138, Pris=349, Storrelse=10, Sjanger="Thriller", Bilde="../Bilder/ShutterIsland.jpg"},
            new Filmer{FId=15, Navn="Django Unchained", Lengde=185, Pris=349, Storrelse=10, Sjanger="Western", Bilde="../Bilder/DjangoUnchained.jpg"}
            };
            filmer.ForEach(f => context.Filmer.Add(f));
            context.SaveChanges();
        }
    }
}
