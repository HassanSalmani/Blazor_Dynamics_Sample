using Blazor_Dynamics_Sample.Shared.Models;
using Blazor_Dynamics_Sample.Shared.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Dynamics_Sample.Shared.DataAccess
{
    public class DataService
    {
        private HttpClient httpClient;
        public DataService()
        {
            httpClient = ConnectionProvider.Current.GetHttpClient();
        }

        public IEnumerable<XrmAccount> GetAccounts()
        {
            try
            {
                string? queryOptions = $"?{QueryOptionHelper.Select}" +
                    $"{XrmAccount.Schema.Name},{XrmAccount.Schema.Phone}";
                
                var response = httpClient.GetAsync(XrmAccount.Schema.AccountUri + queryOptions, HttpCompletionOption.ResponseHeadersRead).Result;
                if (response.IsSuccessStatusCode)
                {
                    var answerTemplates = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject<XrmAccount>>(response.Content.ReadAsStringAsync().Result);

                    return answerTemplates.Value.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }


        public async Task<Guid?> CreateAccount(XrmAccount xrmAccount)
        {
            try
            {

                var jsonItem = Newtonsoft.Json.JsonConvert.SerializeObject(xrmAccount, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                JObject jItem = JObject.Parse(jsonItem);

                HttpRequestMessage createRequest = new HttpRequestMessage(new HttpMethod("POST"), XrmAccount.Schema.AccountUri);
                createRequest.Content = new StringContent(jItem.ToString(),
    Encoding.UTF8, "application/json");
                createRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                using (HttpClient httpClient = ConnectionProvider.Current.GetHttpClient())
                {
                    var response = await httpClient.SendAsync(createRequest, HttpCompletionOption.ResponseContentRead);

                    if (response.IsSuccessStatusCode)
                    {
                        var s = response.Headers.Location.AbsolutePath.Split('(', ')');
                        if (s.Length > 1)
                        {
                            Guid id = new Guid(s[1].ToString());
                            return id;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }


        public async Task UpdateAccount(XrmAccount xrmAccount)
        {
            try
            {
                HttpClient httpClient = ConnectionProvider.Current.GetHttpClient();

                string accountsUri = $"{XrmAccount.Schema.AccountUri}({xrmAccount.Id})";
                var jsonItem = Newtonsoft.Json.JsonConvert.SerializeObject(xrmAccount, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                JObject jItem = JObject.Parse(jsonItem);

                HttpRequestMessage updateRequest = new HttpRequestMessage(new HttpMethod("PATCH"), accountsUri);
                updateRequest.Content = new StringContent(jItem.ToString(),
    Encoding.UTF8, "application/json");
                updateRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var updateResponse = await httpClient.SendAsync(updateRequest, HttpCompletionOption.ResponseContentRead);

                if (updateResponse.IsSuccessStatusCode)
                {

                }
                else
                {

                }


            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
