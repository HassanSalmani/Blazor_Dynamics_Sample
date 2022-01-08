
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security;

namespace Blazor_Dynamics_Sample.Shared.Services
{
    public class ConnectionProvider
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }

        public string EndPointType { get; set; }
        public string ServiceUri { get; set; }

        public static ConnectionProvider Current = new ConnectionProvider();
 

        public HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient((new HttpClientHandler() { Credentials = new NetworkCredential(Current.UserName, Current.Password, Current.Domain) }));
            //Base url of the CRM For e.g. http://servername:port/orgname
            httpClient.BaseAddress = new Uri(Current.ServiceUri);
            return httpClient;
        }
    }
}
