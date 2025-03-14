using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class TraineeWorkoutProgram
    {
        public int TraineeId { get; set; }
        public int WorkoutProgramId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletionDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual Trainee Trainee { get; set; }
        public virtual WorkoutProgram WorkoutProgram { get; set; }
    }
}
