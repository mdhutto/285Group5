using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RisingPhoenix.Models
{
    public partial class Security
    { [Key]
        public int MemberId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public bool ActiveBool { get; set; }

        public Members Member { get; set; }
    }
}
