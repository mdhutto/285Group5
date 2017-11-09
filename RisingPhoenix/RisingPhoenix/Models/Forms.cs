using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RisingPhoenix.Models
{
    public partial class Forms
    {
        public int FormId { get; set; }
        public int FormType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FormDate { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public int? RecipientId2 { get; set; }
        public int? RecipientId3 { get; set; }
        public string Location { get; set; }
        public string ClientName { get; set; }
        public string ClientInfo { get; set; }
        public decimal? Income { get; set; }
        public string NonMemberInfo { get; set; }

        public Forms Form { get; set; }
        public Members Recipient { get; set; }
        public Members Recipient2 { get; set; }
        public Members Recipient3 { get; set; }
        public Members Sender { get; set; }
        
    }
}
