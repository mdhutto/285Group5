using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Referrals
    {
        public Referrals()
        {
            Heresthemoneys = new HashSet<Heresthemoneys>();
            NonmemberData = new HashSet<NonmemberData>();
        }

        public int FormId { get; set; }
        public int SenderId { get; set; }
        public bool? SenderIsMemberBool { get; set; }
        public int RecipientId { get; set; }
        public string Client { get; set; }
        public bool BusinessCard { get; set; }
        public bool CallClient { get; set; }
        public string ClientContact { get; set; }
        public string Comments { get; set; }

        public Forms Form { get; set; }
        public Members Recipient { get; set; }
        public Members Sender { get; set; }
        public ICollection<Heresthemoneys> Heresthemoneys { get; set; }
        public ICollection<NonmemberData> NonmemberData { get; set; }
    }
}
