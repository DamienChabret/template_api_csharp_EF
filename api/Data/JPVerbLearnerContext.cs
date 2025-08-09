using Microsoft.EntityFrameworkCore;
using api.models;

namespace api.Data
{
    public class JPVerbLearnerContext : DbContext
    {
        public JPVerbLearnerContext(){}
        
        public JPVerbLearnerContext(DbContextOptions<JPVerbLearnerContext> options) : base(options)
        {
        }

        public DbSet<Verb> Verbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verb>().ToTable("Verb");

            modelBuilder.Entity<Verb>()
                .Property(v => v.VerbGroup)
                .HasConversion<string>();

            modelBuilder.Entity<Verb>()
                .Property(v => v.JlptLevel)
                .HasConversion<string>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
