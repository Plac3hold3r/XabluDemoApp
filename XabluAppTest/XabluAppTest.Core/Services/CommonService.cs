using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace XabluAppTest.Core.Services
{
    public class CommonService : ICommonService
    {
        public void Post(Dictionary<string, string> headers, Action<string> success, Action<Exception> error, string method, string body)
        {
            throw new NotImplementedException();
        }

        public async Task Get(Dictionary<string, string> headers, Action<string> success, Action<Exception> error, string method)
        {
            var url = $"url{method}";

            var client = new HttpClient { Timeout = new TimeSpan(0, 0, 30) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var h in headers)
            {
                client.DefaultRequestHeaders.Add(h.Key, h.Value);
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            await client.SendAsync(request).ContinueWith(responseTask =>
            {
                try
                {
                    var message = responseTask.Result.EnsureSuccessStatusCode();

                    if (message.IsSuccessStatusCode)
                    {
                        var task = responseTask.Result.Content.ReadAsStringAsync();
                        success(task.Result);
                    }
                    else
                    {
                        error(new Exception("GET error (web response) -> method: " + method));
                    }
                }
                catch (Exception ex)
                {

                    if (ex.Message == "500 (Internal Server Error)")
                    {
                        error(new Exception(ex.Message));
                    }

                    // Session timeout!!!
                    if (ex.Message == "401 (Unauthorized)")
                    {
                        //TODO Login again
                    }
                    else
                    {
                        error(new Exception(ex.Message));
                    }
                }
            });
        }

        public void Delete(Dictionary<string, string> headers, Action<string> success, Action<Exception> error, string method)
        {
            throw new NotImplementedException();
        }

        public void Put(Dictionary<string, string> headers, Action<string> success, Action<Exception> error, string method, string body)
        {
            throw new NotImplementedException();
        }
    }
}
