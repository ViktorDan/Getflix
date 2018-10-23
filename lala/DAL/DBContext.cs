using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Model;

// Her finnes alt som har med oppretting av database å gjøre. DB metoder finner man i DBFunksjonalitet
// Public Virtual lager connection mellom Kunder og Poststeder

namespace DAL
{
    public class DBContext : DbContext
    {
        // Oppretter databasen.
        public DBContext()
            : base("name=WebAppsMedGithub") {}

        // Oppretter tabellene Kunder, Poststeder og Filmer i databasen.
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Film> Filmer { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}