using RovnoZyb.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zyb_Domain.Interfaces
{
    interface iJwtTokenService {
        string CreateToken(User user);
    }
}
