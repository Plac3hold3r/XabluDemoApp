using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XabluAppTest.Core.Services
{
    public interface ICommonService
    {
        void Post(Dictionary<string, string> headers, Action<string> success, Action<Exception> error,
            string method, string body);
        Task Get(Dictionary<string, string> headers, Action<string> success, Action<Exception> error, string method);

        void Delete(Dictionary<string, string> headers, Action<string> success, Action<Exception> error,
            string method);

        void Put(Dictionary<string, string> headers, Action<string> success, Action<Exception> error,
            string method, string body);
    }
}
