using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoShop.Models
{
    public class LoginModel
    {
        public string Email { set; get; }
        public string Password { set; get; }
    }
    public class RegisterModel
    {
        public string Email { set; get; }
        public string Password { set; get; }
    }
}