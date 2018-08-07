namespace AxaAssesment.Models
{
    public class ApiConfiguration
    {
        public string ClientsUrl { get; set; }
        public string PoliciesUrl { get; set; }
        public bool ActiveLicenses { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
