using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace RisingPhoenix.Models
{
    public partial class Forms
    { 
        [Key]
        public int FormId { get; set; }
        [Required]
        [DisplayName("Form")]
        public int FormType { get; set; }
        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FormDate { get; set; }
        [Required]
        [DisplayName("Sender")]
        public int SenderId { get; set; }
        [Required]
        [DisplayName("Recipient")]
        public int RecipientId { get; set; }
        public string Location { get; set; }
        [DisplayName("Client")]
        public string ClientName { get; set; }
        [DisplayName("Client Info")]
        public string ClientInfo { get; set; }
        public decimal? Income { get; set; }
        [DisplayName("Nonmember")]
        public string NonMemberInfo { get; set; }

        [ForeignKey(nameof(SenderId))]
        [Column(Order = 1)]
        public Members Sender { get; set; }
        [ForeignKey(nameof(RecipientId))]
        [Column(Order = 2)]
        public Members Recipient { get; set; }
        
    }
}
