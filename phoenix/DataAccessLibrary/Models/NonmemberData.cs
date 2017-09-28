using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class NonmemberData
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string NonMemberInfo { get; set; }

        public Referrals Form { get; set; }
    }
}
