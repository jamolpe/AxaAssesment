using System;
using System.Collections.Generic;
using System.Text;
using AxaAssesment.Library.Domain.Constants;

namespace AxaAssesment.Library.Domain.Models
{
    public class UserAccessModel
    {
        public TypeRole TypeRole { get; set; }
        public bool ValidRole { get; set; }
    }
}
