using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Utilities
{
    public class ResponsePattern
    {
        internal static dynamic GetSuccessErrorMsg(string Message, dynamic Data = null)
        {
            var MsgObj = new { message = Message, data = Data };
            return MsgObj;
        }
    }
}
