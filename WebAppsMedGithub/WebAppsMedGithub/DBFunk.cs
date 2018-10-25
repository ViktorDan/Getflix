using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using WebAppsMedGithub.Models;

namespace WebAppsMedGithub
{
    public class DBFunk
    {
        public static void RegistrerKunde(Kunde innKunde)
        {
            using (var db = new DBContext())
            {
                try
                {
                    // lag kunde med passord salt+hash, add kunde til tabellen Kunder, og commit ved "savechanges".
                    var nyKunde = new dbKunder
                    {
                        Brukernavn = innKunde.Brukernavn,
                        Fornavn = innKunde.Fornavn,
                        Etternavn = innKunde.Etternavn,
                        Adresse = innKunde.Adresse,
                        Postnr = innKunde.Postnr
                    };

                    var eksistererPostnr = db.Poststeder.Find(innKunde.Postnr);

                    if (eksistererPostnr == null)
                    {
                        var nyttPoststed = new Poststeder()
                        {
                            Postnr = innKunde.Postnr,
                            Poststed = innKunde.Poststed
                        };
                        nyKunde.Poststeder = nyttPoststed;
                    }

                    nyKunde.Tlf = innKunde.Tlf;
                    string salt = lagSalt();
                    var passordOgSalt = innKunde.Passord + salt;
                    byte[] passordDb = lagHash(passordOgSalt);
                    nyKunde.Passord = passordDb;
                    nyKunde.Salt = salt;
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    System.Diagnostics.Debug.WriteLine(feil);
                }
            }
        }



        public static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = SHA512.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public static string lagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }

        public static bool bruker_i_db(Kunde innKunde)
        {
            using (var db = new DBContext())
            {
                dbKunder funnetKunde = db.Kunder.FirstOrDefault(b => b.Brukernavn == innKunde.Brukernavn);
                if (funnetKunde != null)
                {
                    byte[] passordForTest = lagHash(innKunde.Passord + funnetKunde.Salt);
                    bool riktigBruker = funnetKunde.Passord.SequenceEqual(passordForTest);  // merk denne testen!
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }

        
    }
}