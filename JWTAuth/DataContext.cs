using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JWTAuth
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        // Additional DbSet properties for other entities if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, constraints, etc., if needed
            modelBuilder.Entity<User>()
                   .HasMany(u => u.AssignedTasks)
                   .WithOne(t => t.AssignedTo)
                   .HasForeignKey(t => t.AssignedToUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Profile)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                    .HasIndex(u => u.Email)
                    .IsUnique();
            // standard



            // Add additional configurations for other relationships

            base.OnModelCreating(modelBuilder);
        }
    }
}
