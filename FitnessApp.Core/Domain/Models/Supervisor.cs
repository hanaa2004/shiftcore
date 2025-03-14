using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Supervisor : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ExperienceYears { get; set; }

        [MaxLength(500)]
        public string Specialization { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
    }

}
