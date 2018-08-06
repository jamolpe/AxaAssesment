﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    
    [Route("api/[controller]")]
    public class PolicyController : Controller
    {

        private readonly ApiConfiguration _apiConfiguration;
        private readonly IPolicyBusiness _policyBusiness;
        private readonly IClientBusiness _clientBusiness;
        public PolicyController(IOptions<ApiConfiguration> apiConfiguration)
        {
            this._apiConfiguration = apiConfiguration.Value;
            this._policyBusiness = new PolicyBusiness(ApiHelper.ParseConfigurationToLibrarySettings(this._apiConfiguration));
            this._clientBusiness = new ClientBusiness(ApiHelper.ParseConfigurationToLibrarySettings(this._apiConfiguration));
            this._clientBusiness.ConfigureData();
            this._policyBusiness.ConfigureData();
        }

        // GET api/policy/GetClientIdByPolicyNumber/policyNumber
        [HttpGet("[action]/{policyNumber}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        public IActionResult GetClientIdByPolicyNumber(string policyNumber)
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

        // GET api/policy/GetPoliciesByClientId/clientId
        [HttpGet("[action]/{clientId}")]
        [ProducesResponseType(200, Type = typeof(List<PolicyModel>))]
        [ProducesResponseType(404)]
        public IActionResult GetPoliciesByClientId(string clientId)
        {
            List<PolicyModel> result = this._policyBusiness.PoliciesByClientId(clientId);
            
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}