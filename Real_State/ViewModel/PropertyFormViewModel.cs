using Real_State.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Real_State.ViewModel
{
    public class PropertyFormViewModel
    {
        public IEnumerable<PropertyTypes> KindsOfProperty { get; set; }
        public PropertyProfile  Property { get; set; }
        public IEnumerable<Image> image { get; set; }
    }
}