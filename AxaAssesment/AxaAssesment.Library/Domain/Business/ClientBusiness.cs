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
        private readonly ClientRepository _clientRepository;
        private List<ClientModel> _clientModels;

        public ClientBusiness(Settings settings)
        {
            this._clientRepository = new ClientRepository(settings);
        }
        //can return a null
        public ClientModel GetClientDataByUserName(string name)
        { 
            try{
                return this._clientModels == null ? null : this._clientModels.FirstOrDefault(client => client.Name == name);
            }catch(Exception ex){
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        //can return a null
        public ClientModel GetClientDataById(string id)
        {
            try{
                return this._clientModels == null ? null : this._clientModels.FirstOrDefault(client => client.Id == id);
            }catch(Exception ex){
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public void ConfigureData()
        {
            this._clientModels = this.GetClients();
        }

        public TypeRole GetTypeRoleByUserId(string id)
        {
            return this._clientModels.FirstOrDefault(client => client.Id == id).Role;
        }

        public bool CheckClientExist(string id)
        {
            return this._clientModels == null ? false : this._clientModels.Exists(client => client.Id == id);
        }

        private List<ClientModel> GetClients(){
            return this._clientRepository.GetModelAsync<ClientListModel>().Result.Clients;
        }
    }
}
