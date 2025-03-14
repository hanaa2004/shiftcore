using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class WorkoutProgram : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public int DurationWeeks { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public int CreatedByTrainerId { get; set; }

        // Navigation properties
        public virtual Level Level { get; set; }
        public virtual Trainer CreatedByTrainer { get; set; }
        public virtual ICollection<WorkoutSession> WorkoutSessions { get; set; }
        public virtual ICollection<TraineeWorkoutProgram> EnrolledTrainees { get; set; }
    }

}
