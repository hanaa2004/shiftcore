using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Nutrition_Plan : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Calories { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int CreatedByNutritionistId { get; set; }

        // Navigation properties
        public virtual Nutritionist CreatedByNutritionist { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }

}
