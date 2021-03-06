﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RovnoZyb.Entity
{

    [Table("tblMoreInfo")]
    public class UserMoreInfo
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Address { get; set; }
        [Required]
        public int Age { get; set; }

        public virtual User User { get; set; }


        public virtual ICollection<Anketa> Anketas { get; set; }
    }

}
