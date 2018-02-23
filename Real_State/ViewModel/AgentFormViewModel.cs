using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Real_State.Models;


namespace Real_State.ViewModel
{
    public class AgentFormViewModel
    {
        public IEnumerable<Image> Images { get; set; }
        public AgentProfile  AgentProfile { get; set; }
    }
}