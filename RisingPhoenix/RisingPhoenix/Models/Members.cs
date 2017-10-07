using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Members
    {
        public Members()
        {
            Attendance = new HashSet<Attendance>();
            Face2FacesMetId1Navigation = new HashSet<Face2Faces>();
            Face2FacesMetId2Navigation = new HashSet<Face2Faces>();
            Face2FacesMetId3Navigation = new HashSet<Face2Faces>();
            Face2FacesMetId4Navigation = new HashSet<Face2Faces>();
            ReferralsRecipient = new HashSet<Referrals>();
            ReferralsSender = new HashSet<Referrals>();
        }

        public int MemberId { get; set; }
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

        public Security Security { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<Face2Faces> Face2FacesMetId1Navigation { get; set; }
        public ICollection<Face2Faces> Face2FacesMetId2Navigation { get; set; }
        public ICollection<Face2Faces> Face2FacesMetId3Navigation { get; set; }
        public ICollection<Face2Faces> Face2FacesMetId4Navigation { get; set; }
        public ICollection<Referrals> ReferralsRecipient { get; set; }
        public ICollection<Referrals> ReferralsSender { get; set; }
    }
}
