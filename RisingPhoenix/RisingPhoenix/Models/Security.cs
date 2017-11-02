using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Security
    {
        public int MemberId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public bool ActiveBool { get; set; }

        public Members Member { get; set; }
    }
}
