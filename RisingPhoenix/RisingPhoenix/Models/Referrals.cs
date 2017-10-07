using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Referrals
    {
        public Referrals()
        {
            Htmoneys = new HashSet<Htmoneys>();
        }

        public int FormId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public int ClientId { get; set; }
        public string SenderMsg { get; set; }

        public Clients Client { get; set; }
        public Members Recipient { get; set; }
        public Members Sender { get; set; }
        public ICollection<Htmoneys> Htmoneys { get; set; }
    }
}
