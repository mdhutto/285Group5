using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Forms
    {
        public int FormId { get; set; }
        public int FormType { get; set; }
        public DateTime FormDate { get; set; }

        public Face2faces Face2faces { get; set; }
        public Heresthemoneys Heresthemoneys { get; set; }
        public Referrals Referrals { get; set; }
    }
}
