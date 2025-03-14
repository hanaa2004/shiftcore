using FitnessApp.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Interfaces
{
    public interface IAppDbContext
    {
            DbSet<User> Users { get; set; }
            DbSet<Role> Roles { get; set; }
            DbSet<Permission> Permissions { get; set; }

            // User role entities
            DbSet<UserRole> UserRoles { get; set; }
            DbSet<RolePermission> RolePermissions { get; set; }

            // User types
            DbSet<Trainee> Trainees { get; set; }
            DbSet<Trainer> Trainers { get; set; }
            DbSet<Nutritionist> Nutritionists { get; set; }
            DbSet<Supervisor> Supervisors { get; set; }
            DbSet<Admin> Admins { get; set; }

            // Training related entities
            DbSet<Level> Levels { get; set; }
            DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
            DbSet<WorkoutSession> WorkoutSessions { get; set; }
            DbSet<Exercise> Exercises { get; set; }
            DbSet<Video> Videos { get; set; }
            DbSet<TraineeWorkoutProgram> TraineeWorkoutPrograms { get; set; }
            DbSet<WorkoutProgram> Workout_Videos { get; set; }

            // Nutrition related entities
            DbSet<Nutrition_Plan> NutritionPlans { get; set; }
            DbSet<Meal> Meals { get; set; }
            DbSet<MealItem> MealItems { get; set; }

            // Save methods
            int SaveChanges();
            Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

            // Change tracking
            EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
            ChangeTracker ChangeTracker { get; }

            // Model building
            DbSet<TEntity> Set<TEntity>() where TEntity : class;
        
    }
}
