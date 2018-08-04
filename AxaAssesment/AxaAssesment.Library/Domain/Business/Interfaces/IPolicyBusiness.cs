using System;
using System.Collections.Generic;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Business.Interfaces
{
    public interface IPolicyBusiness
    {
        List<PolicyModel> PoliciesByClient(string clientid);
        string GetClientIdByPolicyNumber(string policyNumber);
    }
}
