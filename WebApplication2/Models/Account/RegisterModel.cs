using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Account
{
    public class RegisterModel
    {
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Name is Required")]
        public string FullName { get; set; }

        [Display(Name = "User Name:")]
        [Required(ErrorMessage = "User Name is Required")]

        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Password is Required")]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare(otherProperty: "Password", ErrorMessage = "Password Dosen't Match.")]

        public string ConfirmPassword { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is Required")]

        public string Email { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email:")]
        [Required(ErrorMessage = "Confirm Email is Required")]

        [Compare(otherProperty: "Email", ErrorMessage = "Email Dosen't Match.")]

        public string ConfirmEmail { get; set; }

        [Display(Name = "Role:")]
        [Required(ErrorMessage = "Role is Required")]
        [UIHint("RolesComboBox")]
        public string Role { get; set; }

        [Display(Name = "Gender:")]
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [Display(Name = "Mobile Number.:")]
        [Required(ErrorMessage = "Mobile Number  is Required")]
        public string MobileNo { get; set; }

        [Display(Name = "Active:")]
        [Required(ErrorMessage = "Active  is Required")]
        public bool IsActive { get; set; }
    }
}