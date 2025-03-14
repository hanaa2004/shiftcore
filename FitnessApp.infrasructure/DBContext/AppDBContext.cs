using FitnessApp.Core.Domain.Interfaces;
using FitnessApp.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.infrasructure.DBContext
{
    internal class AppDBContext: DbContext,IAppDbContext
    {
        private DbSet<WorkoutProgram> workout_Videos;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        // User management
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        //   entities
        public DbSet<Trainee > Trainees { get; set; }
        public DbSet<Trainer > Trainers { get; set; }
        public DbSet<Nutritionist > Nutritionists { get; set; }
        public DbSet<Supervisor > Supervisors { get; set; }

        // Training related entities
        public DbSet<Level> Levels { get; set; }
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Video> Videos { get; set; }

        // Nutrition related entities
        public DbSet<Nutrition_Plan> NutritionPlans { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealItem> MealItems { get; set; }

        
        // Create Join tables for many-to-many relationships
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<TraineeWorkoutProgram> TraineeWorkoutPrograms { get; set; }
        public DbSet<WorkoutProgram> Workout_Videos { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);


            // Configure join tables
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<TraineeWorkoutProgram>()
                .HasKey(twp => new { twp.TraineeId, twp.WorkoutProgramId });

            // Configure relationships
            // User - Role (many-to-many)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Role - Permission (many-to-many)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            // Trainee - WorkoutProgram (many-to-many)
            modelBuilder.Entity<TraineeWorkoutProgram>()
                .HasOne(twp => twp.Trainee)
                .WithMany(t => t.WorkoutPrograms)
                .HasForeignKey(twp => twp.TraineeId);

            modelBuilder.Entity<TraineeWorkoutProgram>()
                .HasOne(twp => twp.WorkoutProgram)
                .WithMany(wp => wp.EnrolledTrainees)
                .HasForeignKey(twp => twp.WorkoutProgramId);

            // User -   (one-to-one)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Trainee )
                .WithOne(tp => tp.User)
                .HasForeignKey<Trainee >(tp => tp.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Trainer )
                .WithOne(tp => tp.User)
                .HasForeignKey<Trainer >(tp => tp.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Nutritionist )
                .WithOne(np => np.User)
                .HasForeignKey<Nutritionist >(np => np.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Supervisor )
                .WithOne(sp => sp.User)
                .HasForeignKey<Supervisor >(sp => sp.UserId);

            // Email uniqueness
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configure nullable fields and default values
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Trainee>()
                .Property(t => t.Steps)
                .HasDefaultValue(0);

           
        }

        // Override SaveChanges to automatically set audit fields
        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                    // CreatedBy would ideally be set from the current user context
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                    // ModifiedBy would ideally be set from the current user context
                }
            }
        }
    }
}


