using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Account
{
    public class LoginModel
    {
        [Display(Name = "User Name:")]
        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }
        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me:")]
        public bool RememberMe { get; set; }
    }
}