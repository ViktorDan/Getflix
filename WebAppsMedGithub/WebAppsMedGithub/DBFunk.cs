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
        //Login metoder--------------------------------------------------------------------------------------------------------------------------------------
        // Skal disse metodene være private?
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