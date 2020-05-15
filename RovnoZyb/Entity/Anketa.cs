using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RovnoZyb.Entity
{
   
        [Table("tblAnketa")]
        public class Anketa
        {
            [Key]
            public string AnketaId { get; set; }

            [Required]
            public string FullName { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            public string Phone { get; set; }

            [Required]
            public string Servant { get; set; }

            [Required]
            public string Text { get; set; }

            [Required]
            public string Time { get; set; }

            [Required]
            public bool isClose { get; set; }



            [Required]
            public string id { get; set; }


            public UserMoreInfo UserMore { get; set; }
        }
    
}
