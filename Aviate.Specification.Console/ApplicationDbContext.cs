using Aviate.Specification.Console.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aviate.Specification.Console
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        
        public DbSet<Work> Works { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PersonWork> PersonWorks { get; set; }

        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=Aviate.Persons;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            

            modelBuilder.Entity<PersonWork>()
                .HasOne(pw => pw.Work)
                .WithMany(pw => pw.PersonWorks)
                .HasForeignKey(pw => pw.WorkId);

            modelBuilder.Entity<PersonWork>()
                .HasOne(pw => pw.Person)
                .WithMany(pw => pw.PersonWorks)
                .HasForeignKey(pw => pw.PersonId);
        }
    }
}