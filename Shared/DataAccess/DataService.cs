using Blazor_Dynamics_Sample.Shared.Models;
using Blazor_Dynamics_Sample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
