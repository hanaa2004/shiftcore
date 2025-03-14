using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Meal : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string MealType { get; set; } // Breakfast, Lunch, Dinner, Snack

        [Required]
        public int NutritionPlanId { get; set; }

        // Navigation properties
        public virtual Nutrition_Plan NutritionPlan { get; set; }
        public virtual ICollection<MealItem> MealItems { get; set; }
    }
}
