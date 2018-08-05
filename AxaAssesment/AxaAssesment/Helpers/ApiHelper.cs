using System;
using AxaAssesment.Library.Domain.Constants;
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

        public static ClientResultModel ParseClientModelToResultModel(ClientModel client){
            return new ClientResultModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Role = client.Role.ToString()
            };
        }
    }
}
