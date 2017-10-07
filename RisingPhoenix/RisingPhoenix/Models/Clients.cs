using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Referrals = new HashSet<Referrals>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }

        public ICollection<Referrals> Referrals { get; set; }
    }
}
