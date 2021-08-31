using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Auth.Abstract
{
    public interface IJWTAuthenticationManager
    {
        dynamic Authenticate(string username, string password);
    }
}
