using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class SignupViewModel
    {
        public int UserId { get; set; }

        public string Name {  get; set; }

        public string Email {  get; set; }

        public string Password {  get; set; }

        public string RoleName { get; set; }
    }

}