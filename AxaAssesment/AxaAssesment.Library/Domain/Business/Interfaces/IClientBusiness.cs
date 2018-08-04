using System;
using AxaAssesment.Library.Domain.Constants;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Business.Interfaces
{
    public interface IClientBusiness
    {
        ClientModel GetClientDataById(string id);
        ClientModel GetClientDataByUserName(string name);
        Boolean CheckClientExist(string id);
    }
}
