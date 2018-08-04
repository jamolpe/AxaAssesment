using System;
using System.Collections.Generic;
using System.Text;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Repository
{
    public class PoliciesRepository : ApiCommonData
    {
        public PoliciesRepository(Settings settings) : base(settings.PoliciesUrl){}
    }
}
