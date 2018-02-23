using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Real_State.Models
{
    public class PropertyProfile
    {
        public int ID { get; set; }

        public int BathroomNumber { get; set; }

        public int BedroomNumber { get; set; }

        public float Area { get; set; }

        public String Location { get; set; }

        public float Price { get; set; }

        public String Description { get; set; }

        public int PropertyTypesID { get; set; }

        public PropertyTypes TypesOfProperty { get; set; }

        //public virtual ICollection<Image> Images { get; set; }

    }
}