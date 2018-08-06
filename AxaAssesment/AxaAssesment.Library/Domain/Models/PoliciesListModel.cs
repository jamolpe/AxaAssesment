using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AxaAssesment.Library.Domain.Models
{
    public class PoliciesListModel
    {
        [JsonProperty("policies")]
        public List<PolicyModel> Policies { get; set; }
    }
}
