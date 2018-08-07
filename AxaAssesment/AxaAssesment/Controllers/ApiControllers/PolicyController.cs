using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using AxaAssesment.Helpers;
using AxaAssesment.Library.Domain.Business;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Models;
using AxaAssesment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AxaAssesment.Controllers.ApiControllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class PolicyController : Controller
    {

        private readonly ApiConfiguration _apiConfiguration;
        private readonly IPolicyBusiness _policyBusiness;
        private readonly IClientBusiness _clientBusiness;
        public PolicyController(IOptions<ApiConfiguration> apiConfiguration)
        {
            this._apiConfiguration = apiConfiguration.Value;
            Settings settings = ApiHelper.ParseConfigurationToLibrarySettings(this._apiConfiguration);
            this._policyBusiness = new PolicyBusiness(settings);
            this._clientBusiness = new ClientBusiness(settings);
            this._clientBusiness.ConfigureData();
            this._policyBusiness.ConfigureData();
        }

        // GET api/policy/GetClientIdByPolicyNumber/policyNumber
        [Microsoft.AspNetCore.Mvc.HttpGet("{requestUser}/[action]/{policyNumber}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        public IActionResult GetClientIdByPolicyNumber(string requestUser,string policyNumber)
        {
            if (AuthorizationHelper.IsADminRole(requestUser,this._clientBusiness))
            {
                string userId = this._policyBusiness.GetClientIdByPolicyNumber(policyNumber);
                ClientModel result = this._clientBusiness.GetClientDataById(userId);
                if (result != null)
                {
                    return Ok(ApiHelper.ParseClientModelToResultModel(result));
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        // GET api/policy/GetPoliciesByClientName/username
        [Microsoft.AspNetCore.Mvc.HttpGet("{requestUser}/[action]/{username}")]
        [ProducesResponseType(200, Type = typeof(List<PolicyModel>))]
        [ProducesResponseType(404)]
        public IActionResult GetPoliciesByClientName(string requestUser,string username)
        {
            if (AuthorizationHelper.IsADminRole(requestUser, this._clientBusiness))
            {
                ClientModel user = this._clientBusiness.GetClientDataByUserName(username);
                if (user != null)
                {
                    List<PolicyModel> result = this._policyBusiness.PoliciesByClientId(user.Id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return Unauthorized();
            }
            
        }
    }
}