using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Dynamics_Sample.Shared.Models
{
    [JsonObject(Schema.LogicalName)]
    public class XrmAccount
    {
        public class Schema : XrmBaseEntity.Schema
        {
            public const string SolutionPrefix = "";
            public const string LogicalName = SolutionPrefix + "account";
            public const string EntitySetName = SolutionPrefix + "accounts";
            public const string AccountUri = $"api/data/{Version}{EntitySetName}";
            public const string Name = SolutionPrefix + "name";
            public const string Phone = SolutionPrefix + "telephone1";
            public const string Id = LogicalName + "id";
        }


        [JsonProperty(Schema.Name)]
        public string? Name { get; set; }

        [JsonProperty(Schema.Phone)]
        public string? Phone { get; set; }

        [JsonProperty(Schema.Id)]
        public Guid? Id { get; set; }


        [JsonProperty(Schema.StateCode)]
        public int? StateCode { get; set; }


        [JsonProperty(Schema.StatusCode)]
        public int? StatusCode { get; set; }
    }
}
