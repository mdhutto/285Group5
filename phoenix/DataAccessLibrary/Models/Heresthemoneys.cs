using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Heresthemoneys
    {
        public int FormId { get; set; }
        public int? ReferralFormId { get; set; }
        public string Client { get; set; }
        public decimal Income { get; set; }

        public Forms Form { get; set; }
        public Referrals ReferralForm { get; set; }
    }
}
