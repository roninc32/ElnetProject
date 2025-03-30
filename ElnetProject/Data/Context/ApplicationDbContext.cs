using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElnetProject.Models.Domain.User;
using ElnetProject.Models.Domain.Communication;
using ElnetProject.Models.Domain.Service;

namespace ElnetProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Staff> StaffMembers { get; set; }
        public DbSet<HomeOwner> HomeOwners { get; set; }
        public DbSet<NotificationPreference> NotificationPreferences { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Message relationships
            modelBuilder.Entity<Message>(entity =>
            {
                // Configure Message-Sender relationship
                entity.HasOne(m => m.Sender)
                    .WithMany(u => u.SentMessages)
                    .HasForeignKey(m => m.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure Message-Receiver relationship
                entity.HasOne(m => m.Receiver)
                    .WithMany(u => u.ReceivedMessages)
                    .HasForeignKey(m => m.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure Message-ParentMessage relationship
                entity.HasOne(m => m.ParentMessage)
                    .WithMany(m => m.Replies)
                    .HasForeignKey(m => m.ParentMessageId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure base properties
                entity.Property(m => m.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(m => m.Status).HasDefaultValue("Sent");
                entity.Property(m => m.MessageType).HasDefaultValue("Standard");
            });

            // Configure other entity relationships
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.ApplicationUser)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.ApplicationUser)
                .WithOne(u => u.Staff)
                .HasForeignKey<Staff>(s => s.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HomeOwner>()
                .HasOne(h => h.ApplicationUser)
                .WithOne(u => u.HomeOwner)
                .HasForeignKey<HomeOwner>(h => h.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotificationPreference>()
                .HasOne(np => np.User)
                .WithOne(u => u.NotificationPreference)
                .HasForeignKey<NotificationPreference>(np => np.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}