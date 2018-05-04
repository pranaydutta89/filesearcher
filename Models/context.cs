using Microsoft.EntityFrameworkCore;


namespace fileSearcher.Models
{
    public class fileSearcherContext : DbContext
    {
        public DbSet<searchFolderModel> searchFolders { get; set; }
        public DbSet<fileTypeModel> types { get; set; }
        public DbSet<fileModel> files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=fileSearcher.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<searchFolderModel>()
                 .HasIndex(u => u.folderPath)
                 .IsUnique();
        }
    }
}

