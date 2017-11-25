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
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPass { get; set; }
        [Required]
        public bool ActiveBool { get; set; }

        [ForeignKey(nameof(MemberId))]
        public Members Member { get; set; }
    }
}
