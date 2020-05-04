using System;
using System.Collections.Generic;
using System.Text;

namespace Zyb.DTO.Models.Results
{
    public class ResultDTO
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public string Token { get; set; }
        public List<string> errors { get; set; }
    }
}
