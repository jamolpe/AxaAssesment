using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AxaAssesment.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        public string UserId { get; set; }
        [Required]
        public bool IsThirdParties { get; set; }
    }
}
