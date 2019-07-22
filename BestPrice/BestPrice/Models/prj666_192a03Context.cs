using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BestPrice.Models
{
    public partial class prj666_192a03Context : DbContext
    {
        public prj666_192a03Context()
        {
        }

        public prj666_192a03Context(DbContextOptions<prj666_192a03Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CustomAggregatedCounter> CustomAggregatedCounter { get; set; }
        public virtual DbSet<CustomCounter> CustomCounter { get; set; }
        public virtual DbSet<CustomHash> CustomHash { get; set; }
        public virtual DbSet<CustomJob> CustomJob { get; set; }
        public virtual DbSet<CustomJobParameter> CustomJobParameter { get; set; }
        public virtual DbSet<CustomJobQueue> CustomJobQueue { get; set; }
        public virtual DbSet<CustomJobState> CustomJobState { get; set; }
        public virtual DbSet<CustomList> CustomList { get; set; }
        public virtual DbSet<CustomServer> CustomServer { get; set; }
        public virtual DbSet<CustomSet> CustomSet { get; set; }
        public virtual DbSet<CustomState> CustomState { get; set; }
        public virtual DbSet<Faqs> Faqs { get; set; }
        public virtual DbSet<HangfireAggregatedCounter> HangfireAggregatedCounter { get; set; }
        public virtual DbSet<HangfireCounter> HangfireCounter { get; set; }
        public virtual DbSet<HangfireHash> HangfireHash { get; set; }
        public virtual DbSet<HangfireJob> HangfireJob { get; set; }
        public virtual DbSet<HangfireJobParameter> HangfireJobParameter { get; set; }
        public virtual DbSet<HangfireJobQueue> HangfireJobQueue { get; set; }
        public virtual DbSet<HangfireJobState> HangfireJobState { get; set; }
        public virtual DbSet<HangfireList> HangfireList { get; set; }
        public virtual DbSet<HangfireServer> HangfireServer { get; set; }
        public virtual DbSet<HangfireSet> HangfireSet { get; set; }
        public virtual DbSet<HangfireState> HangfireState { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SearchHistories> SearchHistories { get; set; }
        public virtual DbSet<Sellers> Sellers { get; set; }
        public virtual DbSet<Wishlists> Wishlists { get; set; }

        // Unable to generate entity type for table 'prj666_192a03.Custom_DistributedLock'. Please see the warning messages.
        // Unable to generate entity type for table 'prj666_192a03.Hangfire_DistributedLock'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=mymysql.senecacollege.ca;Uid=prj666_192a03;Pwd=fnML@8473;Database=prj666_192a03;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.ToTable("AspNetRoleClaims", "prj666_192a03");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimType).IsUnicode(false);

                entity.Property(e => e.ClaimValue).IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.ToTable("AspNetRoles", "prj666_192a03");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ConcurrencyStamp).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "prj666_192a03");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimType).IsUnicode(false);

                entity.Property(e => e.ClaimValue).IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("AspNetUserLogins", "prj666_192a03");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).IsUnicode(false);

                entity.Property(e => e.ProviderKey).IsUnicode(false);

                entity.Property(e => e.ProviderDisplayName).IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("AspNetUserRoles", "prj666_192a03");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("AspNetUserTokens", "prj666_192a03");

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.LoginProvider).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.ToTable("AspNetUsers", "prj666_192a03");

                entity.HasIndex(e => e.LocationId)
                    .HasName("LocationId");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.GetNotified)
                    .HasColumnName("getNotified")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsRegistered)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Location).HasColumnType("longtext");

                entity.Property(e => e.LocationId).HasColumnType("int(10)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).IsUnicode(false);

                entity.Property(e => e.PendingEmailChange)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SaveSearches)
                    .HasColumnName("saveSearches")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.SecurityStamp).IsUnicode(false);

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("User_LocationId_FK");
            });

            modelBuilder.Entity<CustomAggregatedCounter>(entity =>
            {
                entity.ToTable("Custom_AggregatedCounter", "prj666_192a03");

                entity.HasIndex(e => e.Key)
                    .HasName("IX_CounterAggregated_Key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("int(11)");
            });

            modelBuilder.Entity<CustomCounter>(entity =>
            {
                entity.ToTable("Custom_Counter", "prj666_192a03");

                entity.HasIndex(e => e.Key)
                    .HasName("IX_Counter_Key");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("int(11)");
            });

            modelBuilder.Entity<CustomHash>(entity =>
            {
                entity.ToTable("Custom_Hash", "prj666_192a03");

                entity.HasIndex(e => new { e.Key, e.Field })
                    .HasName("IX_Hash_Key_Field")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<CustomJob>(entity =>
            {
                entity.ToTable("Custom_Job", "prj666_192a03");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_Job_StateName");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Arguments)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.InvocationData)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.StateId).HasColumnType("int(11)");

                entity.Property(e => e.StateName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomJobParameter>(entity =>
            {
                entity.ToTable("Custom_JobParameter", "prj666_192a03");

                entity.HasIndex(e => e.JobId)
                    .HasName("FK_JobParameter_Job");

                entity.HasIndex(e => new { e.JobId, e.Name })
                    .HasName("IX_JobParameter_JobId_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<CustomJobQueue>(entity =>
            {
                entity.ToTable("Custom_JobQueue", "prj666_192a03");

                entity.HasIndex(e => new { e.Queue, e.FetchedAt })
                    .HasName("IX_JobQueue_QueueAndFetchedAt");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FetchToken)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomJobState>(entity =>
            {
                entity.ToTable("Custom_JobState", "prj666_192a03");

                entity.HasIndex(e => e.JobId)
                    .HasName("FK_JobState_Job");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnType("longtext");

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomList>(entity =>
            {
                entity.ToTable("Custom_List", "prj666_192a03");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<CustomServer>(entity =>
            {
                entity.ToTable("Custom_Server", "prj666_192a03");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<CustomSet>(entity =>
            {
                entity.ToTable("Custom_Set", "prj666_192a03");

                entity.HasIndex(e => new { e.Key, e.Value })
                    .HasName("IX_Set_Key_Value")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomState>(entity =>
            {
                entity.ToTable("Custom_State", "prj666_192a03");

                entity.HasIndex(e => e.JobId)
                    .HasName("FK_HangFire_State_Job");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnType("longtext");

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Faqs>(entity =>
            {
                entity.ToTable("FAQs", "prj666_192a03");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HangfireAggregatedCounter>(entity =>
            {
                entity.ToTable("Hangfire_AggregatedCounter", "prj666_192a03");

                entity.HasIndex(e => e.Key)
                    .HasName("IX_CounterAggregated_Key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("int(11)");
            });

            modelBuilder.Entity<HangfireCounter>(entity =>
            {
                entity.ToTable("Hangfire_Counter", "prj666_192a03");

                entity.HasIndex(e => e.Key)
                    .HasName("IX_Counter_Key");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("int(11)");
            });

            modelBuilder.Entity<HangfireHash>(entity =>
            {
                entity.ToTable("Hangfire_Hash", "prj666_192a03");

                entity.HasIndex(e => new { e.Key, e.Field })
                    .HasName("IX_Hash_Key_Field")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<HangfireJob>(entity =>
            {
                entity.ToTable("Hangfire_Job", "prj666_192a03");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_Job_StateName");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Arguments)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.InvocationData)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.StateId).HasColumnType("int(11)");

                entity.Property(e => e.StateName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HangfireJobParameter>(entity =>
            {
                entity.ToTable("Hangfire_JobParameter", "prj666_192a03");

                entity.HasIndex(e => e.JobId)
                    .HasName("FK_JobParameter_Job");

                entity.HasIndex(e => new { e.JobId, e.Name })
                    .HasName("IX_JobParameter_JobId_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<HangfireJobQueue>(entity =>
            {
                entity.ToTable("Hangfire_JobQueue", "prj666_192a03");

                entity.HasIndex(e => new { e.Queue, e.FetchedAt })
                    .HasName("IX_JobQueue_QueueAndFetchedAt");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FetchToken)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HangfireJobState>(entity =>
            {
                entity.ToTable("Hangfire_JobState", "prj666_192a03");

                entity.HasIndex(e => e.JobId)
                    .HasName("FK_JobState_Job");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnType("longtext");

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HangfireList>(entity =>
            {
                entity.ToTable("Hangfire_List", "prj666_192a03");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<HangfireServer>(entity =>
            {
                entity.ToTable("Hangfire_Server", "prj666_192a03");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<HangfireSet>(entity =>
            {
                entity.ToTable("Hangfire_Set", "prj666_192a03");

                entity.HasIndex(e => new { e.Key, e.Value })
                    .HasName("IX_Set_Key_Value")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HangfireState>(entity =>
            {
                entity.ToTable("Hangfire_State", "prj666_192a03");

                entity.HasIndex(e => e.JobId)
                    .HasName("FK_HangFire_State_Job");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnType("longtext");

                entity.Property(e => e.JobId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("Locations", "prj666_192a03");

                entity.HasIndex(e => e.Address)
                    .HasName("Address")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("Notifications", "prj666_192a03");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.BeforePrice).HasColumnType("float(10,0)");

                entity.Property(e => e.CurrentPrice).HasColumnType("float(10,0)");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PriceStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCondition)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seller)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Notification_UserId_FK");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products", "prj666_192a03");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("Reviews", "prj666_192a03");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("float(10,0)");

                entity.Property(e => e.ProductCondition)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnType("int(1) unsigned").IsRequired();

                entity.Property(e => e.SellerName)
                    //.IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoldOut)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SearchHistories>(entity =>
            {
                entity.ToTable("SearchHistories", "prj666_192a03");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("float(10,0)");

                entity.Property(e => e.ProductCondition)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SellerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoldOut)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SearchHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SearchHistory_UserId_FK");
            });

            modelBuilder.Entity<Sellers>(entity =>
            {
                entity.ToTable("Sellers", "prj666_192a03");

                entity.HasIndex(e => e.Name)
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wishlists>(entity =>
            {
                entity.ToTable("Wishlists", "prj666_192a03");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("float(10,0)");

                entity.Property(e => e.ProductCondition)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SellerName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoldOut)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Wishlist_UserId_FK");
            });
        }
    }
}
