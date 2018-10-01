using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAppsMedGithub.Models;

// Her finnes alt som har med oppretting av database å gjøre. DB metoder finner man i DBFunksjonalitet
// Public Virtual lager connection mellom Kunder og Poststeder

namespace WebAppsMedGithub.Models
{
    public class dbKunder
    {
        [Key]
        public int KId { get; set; }
        public string Brukernavn { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Tlf { get; set; }
        
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
        //public virtual Poststeder Poststeder { get; set; }
    }
    public class Poststeder
    {
        [Key]
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        //public virtual dbKunder Kunder { get; set; }
    }
    public class Filmer
    {
        [Key]
        public int FId { get; set; }
        public string Navn { get; set; }
        public int Lengdxe { get; set; }
        public int Storrelse { get; set; }
        public int Pris { get; set; }
    }

    public class DBContext : DbContext
    {
        // Oppretter database DB hvis den ikke finnes.
        public DBContext()
            // Kaller denne bare for DB, skal sikkert ha et annet navn.
            : base("name=DB") 
        {
            Database.CreateIfNotExists();
        }
        // Oppretter tabellene Kunder, Poststeder og Filmer i databasen.
        public DbSet<dbKunder> Kunder { get; set; }
        public DbSet<Filmer> Filmer { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}