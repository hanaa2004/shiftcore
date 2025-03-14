using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email {  get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }

       
    }
}
