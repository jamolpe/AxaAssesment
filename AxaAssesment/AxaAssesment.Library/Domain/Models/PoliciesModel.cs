using System;
using System.Collections.Generic;
using System.Text;

namespace AxaAssesment.Library.Domain.Models
{
    public class PoliciesModel
    {
        public string Id { get; set; }
        public float AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public string ClientId { get; set; }
    }
}
