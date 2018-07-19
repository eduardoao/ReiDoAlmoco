using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebMvcDoAlmoco.Models;


namespace WebMvcReiDoAlmoco
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Votacao> Votacao { get; set; }
        public DbSet<VotoCandidato> CandidatoVotacao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidato>().HasKey(c => c.Email);

            modelBuilder.Entity<Votacao>().HasKey(v => v.Id);
            modelBuilder.Entity<Votacao>().HasMany(c => c.ListaCandidato);

            modelBuilder.Entity<VotoCandidato>().HasKey(vc => vc.Id);          
        }

    }
   

}
