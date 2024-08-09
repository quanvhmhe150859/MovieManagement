using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CartoonMovieManagement.Models;

public partial class CartoonProductManagementContext : DbContext
{
    public CartoonProductManagementContext()
    {
    }

    public CartoonProductManagementContext(DbContextOptions<CartoonProductManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<CartoonMovie> CartoonMovies { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Cooperator> Cooperators { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeHistory> EmployeeHistories { get; set; }

    public virtual DbSet<EpisodeMovie> EpisodeMovies { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectCooperator> ProjectCooperators { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SalaryChangeLog> SalaryChangeLogs { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Studio> Studios { get; set; }

    public virtual DbSet<StudioDevice> StudioDevices { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<UserLoginLog> UserLoginLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                                      .SetBasePath(Directory.GetCurrentDirectory())
                                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Employee");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Role");
        });

        modelBuilder.Entity<CartoonMovie>(entity =>
        {
            entity.ToTable("CartoonMovie");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.ReleasedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Project).WithMany(p => p.CartoonMovies)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartoonMovie_Project");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.CategoryParent).WithMany(p => p.InverseCategoryParent)
                .HasForeignKey(d => d.CategoryParentId)
                .HasConstraintName("FK_Category_Category");
        });

        modelBuilder.Entity<Cooperator>(entity =>
        {
            entity.HasKey(e => e.CooperatorId).HasName("PK_Cooperate");

            entity.ToTable("Cooperator");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Avatar).IsUnicode(false);
            entity.Property(e => e.CitizenIdentification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Citizen Identification");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date of birth");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.SocialMediaLink)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Studio).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("FK_Employee_Studio");
        });

        modelBuilder.Entity<EmployeeHistory>(entity =>
        {
            entity.HasKey(e => e.EmployeeHistoryId).HasName("PK_ProfilePaper");

            entity.ToTable("EmployeeHistory");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeHistories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfilePaper_Employee");
        });

        modelBuilder.Entity<EpisodeMovie>(entity =>
        {
            entity.ToTable("EpisodeMovie");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MovieLink)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ReleasedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CartoonMovie).WithMany(p => p.EpisodeMovies)
                .HasForeignKey(d => d.CartoonMovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EpisodeMovie_CartoonMovie");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.ReadedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Creater).WithMany(p => p.NotificationCreaters)
                .HasForeignKey(d => d.CreaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_Account");

            entity.HasOne(d => d.Receiver).WithMany(p => p.NotificationReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_Account1");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.HasOne(d => d.Role).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_Role");

            entity.HasOne(d => d.Type).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_Type");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.Budget).HasColumnType("money");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Category");
        });

        modelBuilder.Entity<ProjectCooperator>(entity =>
        {
            entity.ToTable("Project_Cooperator");

            entity.Property(e => e.ProjectCooperatorId).HasColumnName("Project_CooperatorId");

            entity.HasOne(d => d.Cooperator).WithMany(p => p.ProjectCooperators)
                .HasForeignKey(d => d.CooperatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Cooperator_Cooperator");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectCooperators)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Cooperator_Project");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
        });

        modelBuilder.Entity<SalaryChangeLog>(entity =>
        {
            entity.ToTable("SalaryChangeLog");

            entity.Property(e => e.Change).HasColumnType("money");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.SalaryChangeLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalaryChangeLog_Account");

            entity.HasOne(d => d.Employee).WithMany(p => p.SalaryChangeLogs)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalaryChangeLog_Employee");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");
        });

        modelBuilder.Entity<Studio>(entity =>
        {
            entity.ToTable("Studio");
        });

        modelBuilder.Entity<StudioDevice>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("PK_Device");

            entity.ToTable("StudioDevice");

            entity.Property(e => e.DeviceId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.IsOwner).HasColumnName("isOwner");
            entity.Property(e => e.MoneyValue).HasColumnType("money");

            entity.HasOne(d => d.Employee).WithMany(p => p.StudioDevices)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Device_Employee");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.AssignedDate).HasColumnType("datetime");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeadlineDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.ResourceLink).IsUnicode(false);
            entity.Property(e => e.SubmitLink).IsUnicode(false);

            entity.HasOne(d => d.Creater).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CreaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Account");

            entity.HasOne(d => d.EpisodeMovie).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.EpisodeMovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_EpisodeMovie");

            entity.HasOne(d => d.Receiver).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK_Task_Employee");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Status");

            entity.HasOne(d => d.TaskParent).WithMany(p => p.InverseTaskParent)
                .HasForeignKey(d => d.TaskParentId)
                .HasConstraintName("FK_Task_Task");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");
        });

        modelBuilder.Entity<UserLoginLog>(entity =>
        {
            entity.HasKey(e => e.LoginLogId);

            entity.ToTable("UserLoginLog");

            entity.Property(e => e.City)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IpAddress).IsUnicode(false);
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.Region)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TimeZone)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserAgent).IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.UserLoginLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLoginLog_Account");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
