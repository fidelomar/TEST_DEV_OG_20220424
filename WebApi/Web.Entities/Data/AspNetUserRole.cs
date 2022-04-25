using System;
using System.Collections.Generic;

#nullable disable

namespace Web.Entities.Data
{
    public partial class AspNetUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
