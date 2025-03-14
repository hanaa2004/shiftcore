using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class User:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey(nameof(Level))]
        public int LevelId{ get; set; }
        public string LevelName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual Trainee  Trainee  { get; set; }
        public virtual Trainer  Trainer  { get; set; }
        public virtual Nutritionist Nutritionist  { get; set; }
        public virtual Supervisor  Supervisor  { get; set; }

    }
}
