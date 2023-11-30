using Microsoft.EntityFrameworkCore;
using SignalRNotification.Models;

namespace SignalRNotification.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<HubConnection> HubConnections { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;
        //public virtual DbSet<ApplicationUser> ApplicationUser { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HubConnection>(entity =>
            {
                entity.ToTable("HubConnection");

                entity.Property(e => e.ConnectionId)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Message)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MessageType)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NotificationDateTime).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }

    
}
