using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElnetProject.Models.Domain.User;
using ElnetProject.Models.Domain.Communication;
using ElnetProject.Models.Domain.Service;
using ElnetProject.Models.Domain.Billing;
using ElnetProject.Models.Domain.Document;
using ElnetProject.Models.Domain.Event;
using ElnetProject.Models.Domain.Facility;
using ElnetProject.Models.Domain.Forum;
using ElnetProject.Models.Domain.Notice;
using ElnetProject.Models.Domain.Poll;
using ElnetProject.Models.Domain.Security;

namespace ElnetProject.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region DbSet Properties
        // User Management
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Staff> StaffMembers { get; set; } = null!;
        public DbSet<HomeOwner> HomeOwners { get; set; } = null!;

        // Communication
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Announcement> Announcements { get; set; } = null!;
        public DbSet<NotificationPreference> NotificationPreferences { get; set; } = null!;

        // Billing
        public DbSet<Bill> Bills { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

        // Documents
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<DocumentAccess> DocumentAccesses { get; set; } = null!;
        public DbSet<DocumentCategory> DocumentCategories { get; set; } = null!;

        // Events
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventAttendee> EventAttendees { get; set; } = null!;
        public DbSet<EventType> EventTypes { get; set; } = null!;

        // Facilities
        public DbSet<Facility> Facilities { get; set; } = null!;
        public DbSet<FacilityReservation> FacilityReservations { get; set; } = null!;
        public DbSet<FacilityType> FacilityTypes { get; set; } = null!;

        // Forum
        public DbSet<ForumAttachment> ForumAttachments { get; set; } = null!;
        public DbSet<ForumCategory> ForumCategories { get; set; } = null!;
        public DbSet<ForumReply> ForumReplies { get; set; } = null!;
        public DbSet<ForumTopic> ForumTopics { get; set; } = null!;

        // Notices
        public DbSet<Notice> Notices { get; set; } = null!;
        public DbSet<NoticeType> NoticeTypes { get; set; } = null!;

        // Polls
        public DbSet<Poll> Polls { get; set; } = null!;
        public DbSet<PollOption> PollOptions { get; set; } = null!;
        public DbSet<PollVote> PollVotes { get; set; } = null!;

        // Security
        public DbSet<EmergencyContact> EmergencyContacts { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VisitorPass> VisitorPasses { get; set; } = null!;

        // Service Requests
        public DbSet<ServiceRequest> ServiceRequests { get; set; } = null!;
        public DbSet<ServiceRequestUpdate> ServiceRequestUpdates { get; set; } = null!;
        public DbSet<ServiceType> ServiceTypes { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global configuration
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region User Configurations
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.NormalizedUserName).IsUnique();

                entity.HasOne(u => u.NotificationPreference)
                    .WithOne(np => np.User)
                    .HasForeignKey<NotificationPreference>(np => np.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.ServiceRequests)
                    .WithOne()
                    .HasForeignKey("ApplicationUserId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.SentMessages)
                    .WithOne(m => m.Sender)
                    .HasForeignKey(m => m.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.ReceivedMessages)
                    .WithOne(m => m.Receiver)
                    .HasForeignKey(m => m.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

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
            #endregion

            #region Message Configurations
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(m => m.ParentMessage)
                    .WithMany(m => m.Replies)
                    .HasForeignKey(m => m.ParentMessageId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Document Configurations
            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(c => c.Documents)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Uploader)
                    .WithMany()
                    .HasForeignKey(d => d.UploaderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ParentDocument)
                    .WithMany(d => d.Versions)
                    .HasForeignKey(d => d.ParentDocumentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(d => d.AccessRights)
                    .WithOne(da => da.Document)
                    .HasForeignKey(da => da.DocumentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DocumentAccess>(entity =>
            {
                entity.HasOne(da => da.User)
                    .WithMany()
                    .HasForeignKey(da => da.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(da => da.GrantedByAccess)
                    .WithMany(da => da.DelegatedAccesses)
                    .HasForeignKey(da => da.GrantedByAccessId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DocumentCategory>(entity =>
            {
                entity.HasOne(dc => dc.ParentCategory)
                    .WithMany(dc => dc.SubCategories)
                    .HasForeignKey(dc => dc.ParentCategoryId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Event Configurations
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasOne(e => e.EventType)
                    .WithMany(et => et.Events)
                    .HasForeignKey(e => e.EventTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Organizer)
                    .WithMany()
                    .HasForeignKey(e => e.OrganizerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Facility)
                    .WithMany()
                    .HasForeignKey(e => e.FacilityId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Attendees)
                    .WithOne(ea => ea.Event)
                    .HasForeignKey(ea => ea.EventId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Forum Configurations
            modelBuilder.Entity<ForumTopic>(entity =>
            {
                entity.HasOne(ft => ft.Category)
                    .WithMany(fc => fc.Topics)
                    .HasForeignKey(ft => ft.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ft => ft.Author)
                    .WithMany()
                    .HasForeignKey(ft => ft.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ft => ft.LastReplyBy)
                    .WithMany()
                    .HasForeignKey(ft => ft.LastReplyById)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(ft => ft.Replies)
                    .WithOne(fr => fr.Topic)
                    .HasForeignKey(fr => fr.TopicId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(ft => ft.Attachments)
                    .WithOne(fa => fa.Topic)
                    .HasForeignKey(fa => fa.TopicId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ForumReply>(entity =>
            {
                entity.HasOne(fr => fr.Author)
                    .WithMany()
                    .HasForeignKey(fr => fr.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(fr => fr.ParentReply)
                    .WithMany(fr => fr.ChildReplies)
                    .HasForeignKey(fr => fr.ParentReplyId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(fr => fr.Attachments)
                    .WithOne(fa => fa.Reply)
                    .HasForeignKey(fa => fa.ReplyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Service Request Configurations
            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.HasOne(sr => sr.HomeOwner)
                    .WithMany(h => h.ServiceRequests)
                    .HasForeignKey(sr => sr.HomeOwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sr => sr.ServiceType)
                    .WithMany(st => st.ServiceRequests)
                    .HasForeignKey(sr => sr.ServiceTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sr => sr.AssignedTo)
                    .WithMany(s => s.AssignedRequests)
                    .HasForeignKey(sr => sr.AssignedToId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(sr => sr.Updates)
                    .WithOne(sru => sru.ServiceRequest)
                    .HasForeignKey(sru => sru.ServiceRequestId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ServiceRequestUpdate>(entity =>
            {
                entity.HasOne(sru => sru.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(sru => sru.UpdatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sru => sru.OldAssignee)
                    .WithMany()
                    .HasForeignKey("OldAssigneeId")
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sru => sru.NewAssignee)
                    .WithMany()
                    .HasForeignKey(sru => sru.NewAssigneeId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sru => sru.AcknowledgedBy)
                    .WithMany()
                    .HasForeignKey(sru => sru.AcknowledgedById)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Facility Configurations
            modelBuilder.Entity<Facility>(entity =>
            {
                entity.HasOne(f => f.FacilityType)
                    .WithMany(ft => ft.Facilities)
                    .HasForeignKey(f => f.FacilityTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(f => f.Reservations)
                    .WithOne(fr => fr.Facility)
                    .HasForeignKey(fr => fr.FacilityId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Billing Configurations
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasOne(b => b.HomeOwner)
                    .WithMany(h => h.Bills)
                    .HasForeignKey(b => b.HomeOwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(b => b.Payments)
                    .WithOne(p => p.Bill)
                    .HasForeignKey("BillId")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(p => p.HomeOwner)
                    .WithMany(h => h.Payments)
                    .HasForeignKey(p => p.HomeOwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.PaymentMethod)
                    .WithMany(pm => pm.Payments)
                    .HasForeignKey(p => p.PaymentMethodId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.RefundedFromPayment)
                    .WithMany()
                    .HasForeignKey(p => p.RefundedFromPaymentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Poll Configurations
            modelBuilder.Entity<Poll>(entity =>
            {
                entity.HasOne(p => p.Creator)
                    .WithMany()
                    .HasForeignKey(p => p.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.Options)
                    .WithOne(po => po.Poll)
                    .HasForeignKey(po => po.PollId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.Votes)
                    .WithOne(pv => pv.Poll)
                    .HasForeignKey(pv => pv.PollId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PollOption>(entity =>
            {
                entity.HasMany(po => po.Votes)
                    .WithOne(pv => pv.PollOption)
                    .HasForeignKey(pv => pv.PollOptionId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Notice Configurations
            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasOne(n => n.NoticeType)
                    .WithMany(nt => nt.Notices)
                    .HasForeignKey(n => n.NoticeTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(n => n.Author)
                    .WithMany()
                    .HasForeignKey(n => n.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(n => n.Acknowledgements)
                    .WithOne(na => na.Notice)
                    .HasForeignKey(na => na.NoticeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(n => n.Views)
                    .WithOne(nv => nv.Notice)
                    .HasForeignKey(nv => nv.NoticeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Security Configurations
            modelBuilder.Entity<EmergencyContact>(entity =>
            {
                entity.HasOne(ec => ec.HomeOwner)
                    .WithMany()
                    .HasForeignKey(ec => ec.HomeOwnerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(v => v.HomeOwner)
                    .WithMany(h => h.Vehicles)
                    .HasForeignKey(v => v.HomeOwnerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<VisitorPass>(entity =>
            {
                entity.HasOne(vp => vp.HomeOwner)
                    .WithMany()
                    .HasForeignKey(vp => vp.HomeOwnerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion
        }
    }
}
