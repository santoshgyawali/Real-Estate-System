using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Real_State.Models
{
    public class AgentProfile
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public byte ID { get; set; }

        public String Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String LicenseNo { get; set; }

        public int PhoneNo { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        [DataType(DataType.Password)]
        public String Password { get; set; }

        public byte ImageID { get; set; }
        public Image Image { get; set; }

    }
}