﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fusillade;
using Newtonsoft.Json;
using Xablu.WebApiClient;

namespace XabluAppTest.Core.Services
{
    public class TestService
    {
        public async void Test()
        {
            try
            {
                var client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                client.DefaultRequestHeaders.Add("X-Email", "@");
                client.DefaultRequestHeaders.Add("X-Password", "");

                var uri = new Uri("");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var aa = content;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }



            //var webApiClient = new WebApiClient("http://37.157.197.226:26080/rest");
            //webApiClient.Headers.Add("X-Email", "slctest@email.cz");
            //webApiClient.Headers.Add("X-Password", "test");
            //var test = await webApiClient.GetAsync(Priority.Background, "/security/session/v1");
        }
    }
}
