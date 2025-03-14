using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class MealItem : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Proteins { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Carbs { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Fats { get; set; }

        [Required]
        [MaxLength(20)]
        public string Quantity { get; set; } // e.g., "100g", "1 cup"

        [Required]
        public int MealId { get; set; }

        // Navigation properties
        public virtual Meal Meal { get; set; }
    }
}
