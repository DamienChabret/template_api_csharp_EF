using Microsoft.EntityFrameworkCore;
using api.models;

namespace api.Data
{
    public class ExempleContexte : DbContext
    {
        public ExempleContexte(){}
        
        public ExempleContexte(DbContextOptions<ExempleContexte> options) : base(options)
        {
        }

        public DbSet<ClassExemple> EntitiesExemples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassExemple>().ToTable("ClassExemple");

            modelBuilder.Entity<ClassExemple>()
                .Property(v => v.ID)
                .HasConversion<string>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
