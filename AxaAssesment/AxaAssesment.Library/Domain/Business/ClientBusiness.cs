using System;
using System.Collections.Generic;
using System.Linq;
using AxaAssesment.Library.Domain.Business.Interfaces;
using AxaAssesment.Library.Domain.Constants;
using AxaAssesment.Library.Domain.Models;
using AxaAssesment.Library.Domain.Repository;

namespace AxaAssesment.Library.Domain.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private ClientRepository _clientRepository;
        public ClientBusiness(Settings settings)
        {
            this._clientRepository = new ClientRepository(settings);
        }
        //can return a null
        public ClientModel GetClientDataByUserName(string name)
        { 
            List<ClientModel> clientModels = this.GetClients();
            return clientModels == null ? null : clientModels.FirstOrDefault(client => client.Name == name);
        }
        //can return a null
        public ClientModel GetClientDataById(string id)
        {
            List<ClientModel> clientModels = this.GetClients();
            return clientModels == null ? null : clientModels.FirstOrDefault(client => client.Id == id);
        }

        public bool CheckClientExist(string id)
        {
            List<ClientModel> clientModels = this.GetClients();
            return clientModels == null ? false :  clientModels.Exists(client => client.Id == id);
        }

        private List<ClientModel> GetClients(){
            return this._clientRepository.GetModelAsync<ClientListModel>().Result.Clients;
        }
    }
}
