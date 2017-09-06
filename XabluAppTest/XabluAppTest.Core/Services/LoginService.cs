using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XabluAppTest.Core.Services
{
    public class LoginService
    {
        public LoginService()
        {
                // TODO mvx session, mvx infomessage
        }

        public async Task<bool> DoLogin(string username, string password)
        {
            var result = false;

            var headers = new Dictionary<string, string> { { "X-Email", username }, { "X-Password", password }, { "X-Service-Type", "test" } };
            var method = "/security/session/v1";
            //var mre = new ManualResetEvent(false);
            var service = new CommonService();

            await service.Get(headers,
                x =>
                {
                    var test = x;
                    result = true;
                    //var conv = new MvxJsonConverter();
                    //var user = conv.DeserializeObject<User>(x);
                    //mre.Set();
                },
                e =>
                {
                    if (e.Message == "404 (Not Found)")
                    {
                        result = false;
                    }
                    else
                    {
                        result = false;
                    }
                    //mre.Set();
                }, method);

            //mre.WaitOne();

            return result;
        }
    }
}
