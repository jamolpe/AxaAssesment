using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Repository
{
    public class ClientRepository : ApiCommonData
    {
        public ClientRepository(Settings settings) : base(settings.ClientsUrl){}
    }
}
