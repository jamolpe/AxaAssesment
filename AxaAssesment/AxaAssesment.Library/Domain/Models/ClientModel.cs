using System;
using System.Collections.Generic;
using System.Text;
using AxaAssesment.Library.Domain.Constants;

namespace AxaAssesment.Library.Domain.Models
{
    public class ClientModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TypeRole Role { get; set; }
    }
}
