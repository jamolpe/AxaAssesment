using System.Collections.Generic;
using AxaAssesment.Helpers;
using AxaAssesment.Library.Domain.Business;
using AxaAssesment.Library.Domain.Models;
using AxaAssesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AxaAssesment.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private ApiConfiguration _apiConfiguration;
        private ClientBusiness _clientBusiness;

        public UsersController(IOptions<ApiConfiguration> apiConfiguration)
        {
            this._apiConfiguration = apiConfiguration.Value;
            this._clientBusiness = new ClientBusiness(ApiHelper.ParseConfigurationToLibrarySettings(this._apiConfiguration));
        }


        // GET api/users/GetClientById/id
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        public IActionResult GetClientById(string id)
        {
            ClientModel result = this._clientBusiness.GetClientDataById(id);
            if (result != null)
            {
                return Ok(ApiHelper.ParseClientModelToResultModel(result));
            }
            else {
                return NotFound();
            }
        }
        // GET api/users/GetClientByUsername/username
        [Route("[action]/{username}")]
        [ProducesResponseType(200, Type = typeof(ClientResultModel))]
        [ProducesResponseType(404)]
        public IActionResult GetClientByUsername(string username)
        {
            ClientModel result = this._clientBusiness.GetClientDataByUserName(username);
            if(result != null){
                return Ok(ApiHelper.ParseClientModelToResultModel(result));
            }else{
                return  NotFound();
            }

        }

    }
}
