using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zyb.DTO.Models
{
    public class AnketaDTO
    {
        [Required(ErrorMessage = "Enter FullName!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Title!")]
        public string Title { get; set; }

        public string Text { get; set; }

        [Required(ErrorMessage = "Enter Phone!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Servant!")]
        public string Servant { get; set; }


        public bool isClose { get; set; }
    }
}
