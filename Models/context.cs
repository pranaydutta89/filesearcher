using Microsoft.EntityFrameworkCore;


namespace fileSearcher.Models
{
    public class fileSearcherContext : DbContext
    {
        public DbSet<searchFolder> searchFolders { get; set; }
        public DbSet<fileType> types { get; set; }
        public DbSet<file> files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=fileSearcher.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<searchFolder>()
                 .HasIndex(u => u.folderPath)
                 .IsUnique();
        }
    }
}

