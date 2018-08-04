using System;
using AxaAssesment.Library.Domain.Constants;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Business.Interfaces
{
    public interface IClientBusiness
    {
        ClientModel GetClientData(string id);
        Boolean CheckClientAccess(string id);
        TypeRole GetClientTypeRole(string id);
        ClientModel GetClientByUserName(string name);
    }
}
