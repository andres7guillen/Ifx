using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfxData.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {

    }

    public class UserRole : IdentityRole<Guid>
    {

    }
}
