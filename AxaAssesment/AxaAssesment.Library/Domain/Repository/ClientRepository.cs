using System;
using System.Collections.Generic;
using System.Text;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Repository
{
    public class ClientRepository
    {
        private string _serviceDataUrl;
        public ClientRepository(Settings settings)
        {
            this._serviceDataUrl = settings.ClientsUrl;
        }
    }
}
