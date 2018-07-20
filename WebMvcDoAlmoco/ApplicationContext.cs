using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebMvcDoAlmoco.Models;


namespace WebMvcReiDoAlmoco
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Eleicao> Eleicao { get; set; }
        public DbSet<Voto> Voto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Candidato>().HasKey(c => c.Id);           

            //modelBuilder.Entity<Eleicao>().HasKey(v => v.Id);
            //modelBuilder.Entity<Eleicao>().HasMany(c => c.Voto);
            //modelBuilder.Entity<Eleicao>().HasMany(c => c.ListaCandidato);
            //modelBuilder.Entity<Voto>().HasKey(vc => vc.Id);
            //modelBuilder.Entity<Voto>().HasOne(vc => vc.Candidato);

            // modelBuilder.Entity<Candidato>().Property(k => k.Id)..HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // modelBuilder.Entity<Candidato>().HasIndex(c => c.Email).IsUnique();
        }

    }
   

}
