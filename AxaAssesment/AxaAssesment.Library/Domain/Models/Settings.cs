using System;
using System.Collections.Generic;
using System.Text;

namespace AxaAssesment.Library.Domain.Models
{
    public class Settings
    {
        public string ClientsUrl { get; set; }
        public string PoliciesUrl { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
