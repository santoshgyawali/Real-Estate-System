using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_State.Models
{
    public class Image
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public byte ID { get; set; }

        public String ImageName { get; set; }

        public String ImagePath { get; set; }


    }
}