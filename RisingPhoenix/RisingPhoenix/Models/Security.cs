using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RisingPhoenix.Models
{
    public partial class Security
    {
        [Key]
        public int MemberId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public bool ActiveBool { get; set; }

        public Members Member { get; set; }
    }
}
