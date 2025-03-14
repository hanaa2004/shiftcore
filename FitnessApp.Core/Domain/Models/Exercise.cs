using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Exercise : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Sets { get; set; }

        [Required]
        public int Reps { get; set; }

        public int? RestSeconds { get; set; }

        [Required]
        public int WorkoutSessionId { get; set; }

        public int? VideoId { get; set; }

        // Navigation properties
        public virtual WorkoutSession WorkoutSession { get; set; }
        public virtual Video Video { get; set; }
    }

}
