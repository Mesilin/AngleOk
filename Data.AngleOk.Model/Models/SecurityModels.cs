using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AngleOk.Model.Models
{
    public class RegisterUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class LoginUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
