using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Accounts
{
    public class Login
    {
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
