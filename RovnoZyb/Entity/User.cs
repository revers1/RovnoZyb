
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RovnoZyb.Entity
{
    public class User : IdentityUser
    {
        public virtual UserMoreInfo UserMoreInfo { get; set; }

    }
}
