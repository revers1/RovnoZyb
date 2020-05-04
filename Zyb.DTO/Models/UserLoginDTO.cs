using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zyb.DTO.Models.Results
{
  public class UserLoginDTO
    {
        [Required(ErrorMessage = "Enter email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter password!")]
        public string Password { get; set; }
    }
}
