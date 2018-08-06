using System;
using System.Collections.Generic;
using System.Text;
using AxaAssesment.Library.Domain.Models;

namespace AxaAssesment.Library.Domain.Repository
{
    public class PolicyRepository : ApiCommonData
    {
        public PolicyRepository(Settings settings) : base(settings.PoliciesUrl){}
    }
}
