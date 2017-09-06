using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XabluAppTest.Core.Enums;

namespace XabluAppTest.Core.Interfaces
{
    public interface ISessionInfo
    {
        Guid Id { get; set; }
        string LoginName { get; set; }
        string Password { get; set; }
        bool IsLogout { get; set; }
        ApiServiceTypes ApiService { get; set; }
    }
}
