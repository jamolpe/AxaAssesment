using System;
using AxaAssesment.Library.Domain.Models;
using AxaAssesment.Models;

namespace AxaAssesment.Helpers
{
    public static class ApiHelper
    {
        public static Settings ParseConfigurationToLibrarySettings(ApiConfiguration apiConfiguration)
        {
            return new Settings { ClientsUrl = apiConfiguration.ClientsUrl, PoliciesUrl = apiConfiguration.PoliciesUrl };
        }
    }
}
