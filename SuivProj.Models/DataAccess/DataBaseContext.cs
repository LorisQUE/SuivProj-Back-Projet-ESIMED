using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuivProj.Models.Classes;


namespace SuivProj.Models.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Projet> Projet { get; set; }
        public DbSet<Exigence> Exigence { get; set; }
        public DbSet<Jalon> Jalon { get; set; }
        public DbSet<Tache> Tache { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Utilisateur>()
                .HasIndex(u => u.Trigramme)
                .IsUnique();
        }
    }
}
