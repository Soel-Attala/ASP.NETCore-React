using System;
using System.Collections.Generic;

namespace SalesSystem.Entity
{
    public partial class Role
    {
        public Role()
        {
            RoleMenus = new HashSet<RoleMenu>();
            UserData = new HashSet<UserData>();
        }

        public int IdRole { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
        public virtual ICollection<UserData> UserData { get; set; }
    }
}
