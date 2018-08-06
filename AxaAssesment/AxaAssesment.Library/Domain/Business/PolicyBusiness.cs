using System;
using System.Collections.Generic;
using System.Linq;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Models;
using AxaAssesment.Library.Domain.Repository;

namespace AxaAssesment.Library.Domain.Business
{
    public class PolicyBusiness : IPolicyBusiness
    {
        private readonly PolicyRepository _policyRepository;
        private List<PolicyModel> _policyModels;
        public PolicyBusiness(Settings settings)
        {
            this._policyRepository = new PolicyRepository(settings);
        }

        public void ConfigureData()
        {
            this._policyModels = GetPolicies();
        }

        public string GetClientIdByPolicyNumber(string policyNumber)
        {
            try
            {
                return this._policyModels == null ? null : this._policyModels.FirstOrDefault(policy => policy.Id == policyNumber)?.ClientId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public List<PolicyModel> PoliciesByClientId(string clientid)
        {
            try
            {
                return this._policyModels == null ? null : this._policyModels.Where(policy => policy.ClientId == clientid).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        private List<PolicyModel> GetPolicies()
        {
            return this._policyRepository.GetModelAsync<PoliciesListModel>().Result.Policies;
        }
    }
}
