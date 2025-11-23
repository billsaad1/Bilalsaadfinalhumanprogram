using HumanitarianProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class HpmDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ProjectIndicator> ProjectIndicators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<DetailedBudgetLine> DetailedBudgetLines { get; set; }
        public DbSet<ItemizedBudgetDetail> ItemizedBudgetDetails { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<BeneficiaryList> BeneficiaryLists { get; set; }
        public DbSet<ProjectReport> ProjectReports { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FollowUpVisit> FollowUpVisits { get; set; }

        public HpmDbContext(DbContextOptions<HpmDbContext> options) : base(options) { }
        public HpmDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HumanitarianProjectsDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Outcome>().ToTable("Outcome");
            modelBuilder.Entity<Output>().ToTable("Output");
            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<ProjectIndicator>().ToTable("ProjectIndicator");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<Section>().ToTable("Sections");
            modelBuilder.Entity<DetailedBudgetLine>().ToTable("DetailedBudgetLine");
            modelBuilder.Entity<ItemizedBudgetDetail>().ToTable("ItemizedBudgetDetail");
            modelBuilder.Entity<Beneficiary>().ToTable("Beneficiary");
            modelBuilder.Entity<BeneficiaryList>().ToTable("BeneficiaryList");
            modelBuilder.Entity<ProjectReport>().ToTable("ProjectReport");
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<FollowUpVisit>().ToTable("FollowUpVisit");

            modelBuilder.Entity<Project>().HasKey(p => p.ProjectID);
            modelBuilder.Entity<Outcome>().HasKey(o => o.OutcomeID);
            modelBuilder.Entity<Output>().HasKey(op => op.OutputID);
            modelBuilder.Entity<Activity>().HasKey(a => a.ActivityID);
            modelBuilder.Entity<ProjectIndicator>().HasKey(pi => pi.ProjectIndicatorID);
            modelBuilder.Entity<User>().HasKey(u => u.UserID);
            modelBuilder.Entity<Role>().HasKey(r => r.RoleID);
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserID, ur.RoleID });
            modelBuilder.Entity<Section>().HasKey(s => s.SectionID);
            modelBuilder.Entity<DetailedBudgetLine>().HasKey(dbl => dbl.DetailedBudgetLineID);
            modelBuilder.Entity<ItemizedBudgetDetail>().HasKey(ibd => ibd.ItemizedBudgetDetailID);

            modelBuilder.Entity<DetailedBudgetLine>(entity =>
            {
                entity.HasOne(d => d.Project)
                      .WithMany(p => p.DetailedBudgetLines)
                      .HasForeignKey(d => d.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ParentDetailedBudgetLine)
                      .WithMany(p => p.ChildDetailedBudgetLines)
                      .HasForeignKey(d => d.ParentDetailedBudgetLineID)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.Property(e => e.UnitCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PercentageChargedToCBPF).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Description).HasMaxLength(1500);
                entity.Property(e => e.Unit).HasMaxLength(50);
                entity.Property(e => e.ItemName).HasMaxLength(255);
            });

            modelBuilder.Entity<ItemizedBudgetDetail>(entity =>
            {
                entity.HasOne(ibd => ibd.ParentBudgetLine)
                      .WithMany(dbl => dbl.ItemizedDetails)
                      .HasForeignKey(ibd => ibd.ParentBudgetLineID)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalCost).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).IsRequired(false);
                entity.Property(e => e.Quantity).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Outcome>()
                .HasOne(o => o.Project)
                .WithMany(p => p.Outcomes)
                .HasForeignKey(o => o.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Outcome>()
                .HasMany(o => o.Outputs)
                .WithOne(op => op.Outcome)
                .HasForeignKey(op => op.OutcomeID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProjectIndicator>()
                .HasOne(pi => pi.Output)
                .WithMany(o => o.ProjectIndicators)
                .HasForeignKey(pi => pi.OutputID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Output>()
                .HasMany(op => op.Activities)
                .WithOne(a => a.Output)
                .HasForeignKey(a => a.OutputID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID);

            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 1, RoleName = "Administrator", Description = "Full system access" });
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("123");
            modelBuilder.Entity<User>().HasData(new User { UserID = 1, Username = "bill", PasswordHash = hashedPassword, Email = "bill@example.com", FullName = "Bill Admin", IsActive = true, CreatedAt = new System.DateTime(2024, 1, 1, 0, 0, 0, System.DateTimeKind.Utc), PhoneNumber = null, LastLogin = null });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserID = 1, RoleID = 1 });
        }
    }
}
