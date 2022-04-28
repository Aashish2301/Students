using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Account
{
    public class ChangePasswordModel
    {
        [Display(Name="Old Password")]
        [Required(ErrorMessage ="Old Password is Required.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "New Password is Required.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is Required.")]
        [DataType(DataType.Password)]
        [Compare(otherProperty:"NewPassword",ErrorMessage ="New Password Doesn't Match.")]
        public string ConfirmPassword { get; set; }
    }
}