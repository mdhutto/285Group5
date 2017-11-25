using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RisingPhoenix.Models
{
    public partial class Security    
    { 
    	[Key]
        [DisplayName("User")]
        public int MemberId { get; set; }
        [Required]
        [DisplayName("Email")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Verify Password")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }
        [Required]
        public bool ActiveBool { get; set; }

        [ForeignKey(nameof(MemberId))]
        public Members Member { get; set; }
    }
}
