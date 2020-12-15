using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AppointmentScheduler.Core.Entity
{
    public class User : IdentityUser
    {
        public int RoleId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
