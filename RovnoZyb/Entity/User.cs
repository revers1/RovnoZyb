
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RovnoZyb.Entity
{
    public class User : IdentityUser//успадк от дэфолт юзера
    {
        public virtual UserMoreInfo UserMoreInfo { get; set; }
     


    }

}
