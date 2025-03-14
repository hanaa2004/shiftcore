using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Domain.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        // Navigation properties
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
