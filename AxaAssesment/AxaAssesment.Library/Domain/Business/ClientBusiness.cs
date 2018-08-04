using System;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Constants;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Business
{
    public class ClientBusiness : IClientBusiness
    {
        public ClientBusiness()
        {
        }

        public bool CheckClientAccess(string id)
        {
            throw new NotImplementedException();
        }

        public ClientModel GetClientByUserName(string name)
        {
            throw new NotImplementedException();
        }

        public ClientModel GetClientData(string id)
        {
            throw new NotImplementedException();
        }

        public TypeRole GetClientTypeRole(string id)
        {
            throw new NotImplementedException();
        }
    }
}
