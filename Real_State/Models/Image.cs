using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Real_State.Models
{
    public class Image
    {
        public byte ID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public virtual PropertyProfile PropertyProfile { get; set; }
        public int PropertyProfileID { get; set; }
    }
}