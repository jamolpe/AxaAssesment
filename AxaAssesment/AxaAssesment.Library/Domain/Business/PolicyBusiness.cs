using System;
using System.Collections.Generic;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Business
{
    public class PolicyBusiness : IPolicyBusiness
    {
        public PolicyBusiness()
        {
        }

        public string GetClientIdByPolicyNumber(string policyNumber)
        {
            throw new NotImplementedException();
        }

        public List<PolicyModel> PoliciesByClient(string clientid)
        {
            throw new NotImplementedException();
        }
    }
}
