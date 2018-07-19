using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiReiDoAlmoco.Models;

namespace WebApiReiDoAlmoco
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {


        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Votacao> Votacaos { get; set; }
        public DbSet<VotoCandidato> CandidatoVotacaos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidato>().HasKey(c => c.Id);

            modelBuilder.Entity<Votacao>().HasKey(v => v.Id);
            modelBuilder.Entity<Votacao>().HasMany(c => c.ListaCandidato);

            modelBuilder.Entity<VotoCandidato>().HasKey(vc => vc.Id);          
        }

    }
}
