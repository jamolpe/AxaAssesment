using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Constants;
using AxaAssesment.Models;

namespace AxaAssesment.Helpers
{
    public class AuthorizationHelper
    {
        public static Boolean IsADminRole(string userId, IClientBusiness clientBusiness)
        {
           return clientBusiness.GetTypeRoleByUserId(userId) == TypeRole.Admin;
        }

        public static Boolean IsUserRole(string userId, IClientBusiness clientBusiness)
        {
            return clientBusiness.GetTypeRoleByUserId(userId) == TypeRole.User;
        }
       
    }
}