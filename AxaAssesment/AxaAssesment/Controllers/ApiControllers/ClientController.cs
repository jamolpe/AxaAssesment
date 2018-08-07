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
    [Authorize]
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
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetClientById(string id)
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
        // GET api/client/GetClientByUsername/username
        [Route("[action]/{username}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetClientByUsername(string username)
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
    }
}
