using System;
using System.Collections.Generic;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Business.Interfaces
{
    public interface IPolicyBusiness
    {
        List<PolicyModel> PoliciesByClientId(string clientid);
        string GetClientIdByPolicyNumber(string policyNumber);
        void ConfigureData();
    }
}
