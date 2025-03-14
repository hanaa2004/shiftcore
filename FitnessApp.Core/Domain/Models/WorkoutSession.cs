using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class WorkoutSession : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int DayNumber { get; set; }

        [Required]
        public int WorkoutProgramId { get; set; }

        // Navigation properties
        public virtual WorkoutProgram WorkoutProgram { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
