using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Real_State.Models
{
    public class EmailForm
    {
        public string To { get; set; }
        public String From { get; set; }
        [Phone]
        public int PhoneNo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}