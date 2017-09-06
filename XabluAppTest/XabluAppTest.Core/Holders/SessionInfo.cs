using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XabluAppTest.Core.Enums;
using XabluAppTest.Core.Interfaces;

namespace XabluAppTest.Core.Holders
{
    public class SessionInfo : ISessionInfo
    {
        public Guid Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool IsLogout { get; set; }
        public ApiServiceTypes ApiService { get; set; }
    }
}
