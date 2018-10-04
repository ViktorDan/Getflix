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
        // Skal disse metodene være private?
        public static void RegistrerKunde(Kunde innKunde)
        {
            using (var db = new DBContext())
            {
                try
                {
                    // lag kunde med passord salt+hash, add kunde til tabellen Kunder, og commit ved "savechanges".
                    var nyKunde = new dbKunder();
                    nyKunde.Brukernavn = innKunde.Brukernavn;
                    nyKunde.Fornavn = innKunde.Fornavn;
                    nyKunde.Etternavn = innKunde.Etternavn;
                    nyKunde.Adresse = innKunde.Adresse;
                    nyKunde.Postnr = innKunde.Postnr;
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

        public static void SjekkPoststed(Kunde innKunde)
        {

        }

        //Login metoder--------------------------------------------------------------------------------------------------------------------------------------
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
        //Login metoder slutt--------------------------------------------------------------------------------------------------------------------------------
    }
}