using System.Collections.Generic;
using AxaAssesment.Helpers;
using AxaAssesment.Library.Domain.Business;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Models;
using AxaAssesment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AxaAssesment.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly ApiConfiguration _apiConfiguration;
        private readonly IClientBusiness _clientBusiness;

        public ClientController(IOptions<ApiConfiguration> apiConfiguration)
        {
            this._apiConfiguration = apiConfiguration.Value;
            this._clientBusiness = new ClientBusiness(ApiHelper.ParseConfigurationToLibrarySettings(this._apiConfiguration));
            this._clientBusiness.ConfigureData();
        }


        // GET api/client/GetClientById/id
        [HttpGet("{requestUser}/[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        public IActionResult GetClientById(string requestUser,string id)
        {
            if (AuthorizationHelper.IsADminRole(requestUser, this._clientBusiness) ||
                AuthorizationHelper.IsUserRole(requestUser, this._clientBusiness))
            {
                ClientModel result = this._clientBusiness.GetClientDataById(id);
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
        // GET api/client/GetClientByUsername/username
        [Route("{requestUser}/[action]/{username}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        public IActionResult GetClientByUsername(string requestUser,string username)
        {
            if (AuthorizationHelper.IsADminRole(requestUser, this._clientBusiness) ||
                AuthorizationHelper.IsUserRole(requestUser, this._clientBusiness))
            {
                ClientModel result = this._clientBusiness.GetClientDataByUserName(username);
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

    }
}
