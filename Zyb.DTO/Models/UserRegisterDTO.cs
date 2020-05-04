using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zyb.DTO.Models
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Full Name is required!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        //[EmailAddress(ErrorMessage ="Email is not correct!")]
        //[CustomEmail(ErrorMessage ="Email is registered")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone Number is required!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Age is required!")]
        public int Age { get; set; }
    }
}
