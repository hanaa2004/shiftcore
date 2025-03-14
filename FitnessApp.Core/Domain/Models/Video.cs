using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Video : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Link { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int? LevelId { get; set; }

        // Navigation properties
        public virtual Level Level { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
