using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AxaAssesment.Helpers;
using AxaAssesment.Library.Domain.Business;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Constants;
using AxaAssesment.Library.Domain.Models;
using AxaAssesment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AxaAssesment.Controllers.ApiControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly ApiConfiguration _apiConfiguration;
        private readonly IClientBusiness _clientBusiness;
        public SecurityController(IOptions<ApiConfiguration> apiConfiguration)
        {
            this._apiConfiguration = apiConfiguration.Value;
            this._clientBusiness = new ClientBusiness(ApiHelper.ParseConfigurationToLibrarySettings(this._apiConfiguration));
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public IActionResult Post([FromBody]LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                string role = TypeRole.User.ToString();
                if (loginViewModel.IsThirdParties && !this._apiConfiguration.ThirdPartiesTokensActive)
                {
                    return BadRequest("Third parties tokens not allowed");
                }

                if (!loginViewModel.IsThirdParties)
                {
                    this._clientBusiness.ConfigureData();
                    if (this._clientBusiness.CheckClientExist(loginViewModel.UserId))
                    {
                        role = this._clientBusiness.GetTypeRoleByUserId(loginViewModel.UserId).ToString();
                    }
                }
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, loginViewModel.Username),
                    new Claim(ClaimTypes.Role, role)
                };

                var token = new JwtSecurityToken
                (
                    issuer: this._apiConfiguration.Issuer,
                    audience: this._apiConfiguration.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(this._apiConfiguration.TokenExpirationDays),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._apiConfiguration.SecretKey)),
                        SecurityAlgorithms.HmacSha256)
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }
    }
}