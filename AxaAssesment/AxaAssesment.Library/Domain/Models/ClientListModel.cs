using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxaAssesment.Library.Domain.Models
{
    public class ClientListModel
    {
        [JsonProperty("Clients")]
        public List<ClientModel> Clients { get; set; }
    }
}
