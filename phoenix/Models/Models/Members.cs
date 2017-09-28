using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Members
    {
        public Members()
        {
            Attendance = new HashSet<Attendance>();
            Face2facesMetId1Navigation = new HashSet<Face2faces>();
            Face2facesMetId2Navigation = new HashSet<Face2faces>();
            Face2facesMetId3Navigation = new HashSet<Face2faces>();
            Face2facesMetId4Navigation = new HashSet<Face2faces>();
            ReferralsRecipient = new HashSet<Referrals>();
            ReferralsSender = new HashSet<Referrals>();
        }

        public int MemberId { get; set; }
        public string Username { get; set; }
        public string UserPw { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public byte[] Photo { get; set; }
        public string Company { get; set; }
        public string Profession { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime MemberSince { get; set; }
        public int AbsenceCount { get; set; }
        public bool AdminBool { get; set; }
        public bool ActiveBool { get; set; }

        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<Face2faces> Face2facesMetId1Navigation { get; set; }
        public ICollection<Face2faces> Face2facesMetId2Navigation { get; set; }
        public ICollection<Face2faces> Face2facesMetId3Navigation { get; set; }
        public ICollection<Face2faces> Face2facesMetId4Navigation { get; set; }
        public ICollection<Referrals> ReferralsRecipient { get; set; }
        public ICollection<Referrals> ReferralsSender { get; set; }
    }
}
