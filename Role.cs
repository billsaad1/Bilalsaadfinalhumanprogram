using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanitarianProjectManagement.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [StringLength(100)]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; } // NVARCHAR(MAX) -> string

        // Navigation property for UserRoles
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }
}
