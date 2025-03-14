using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Trainee:BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Height { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Weight { get; set; }

        [MaxLength(50)]
        public string TypeOfTraining { get; set; }

        [Required]
        public int Steps { get; set; }

        [Required]
        public int LevelId { get; set; }

        public int? SupervisorId { get; set; }

        public int? NutritionPlanId { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Level Level { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public virtual Nutrition_Plan NutritionPlan { get; set; }
        public virtual ICollection<TraineeWorkoutProgram> WorkoutPrograms { get; set; }
    }
    
}
