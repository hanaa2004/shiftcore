using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Level:BaseEntity
    {
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Steps { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<WorkoutProgram> WorkoutVideos { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
