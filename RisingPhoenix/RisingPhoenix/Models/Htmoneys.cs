using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Htmoneys
    {
        public int FormId { get; set; }
        public int RefFormId { get; set; }
        public decimal Income { get; set; }

        public Forms Form { get; set; }
        public Referrals RefForm { get; set; }
    }
}
