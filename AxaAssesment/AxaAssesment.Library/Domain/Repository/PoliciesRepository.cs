using System;
using System.Collections.Generic;
using System.Text;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Repository
{
    public class PoliciesRepository
    {
        private string _serviceDataUrl;
        public PoliciesRepository(Settings settings)
        {
            this._serviceDataUrl = settings.PoliciesUrl;
        }
    }
}
