using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RisingPhoenix.Models
{
    public partial class Forms
    { 
        [Key]
        public int FormId { get; set; }
        [Required]
        public int FormType { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FormDate { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        public string Location { get; set; }
        [DisplayName("Client Name")]
        public string ClientName { get; set; }
        [DisplayName("Client Info")]
        public string ClientInfo { get; set; }
        public decimal? Income { get; set; }
        [DisplayName("Nonmember Info")]
        public string NonMemberInfo { get; set; }

        [ForeignKey(nameof(SenderId))]
        [Column(Order = 1)]
        public Members Sender { get; set; }
        [ForeignKey(nameof(RecipientId))]
        [Column(Order = 2)]
        public Members Recipient { get; set; }
        
    }
}
