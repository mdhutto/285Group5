using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Members
    {
        public Members()
        {
            Attendance = new HashSet<Attendance>();
            FormsRecipient = new HashSet<Forms>();
            FormsRecipientId2Navigation = new HashSet<Forms>();
            FormsRecipientId3Navigation = new HashSet<Forms>();
            FormsSender = new HashSet<Forms>();
        }

        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Profession { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime MemberSince { get; set; }
        public int AbsenceCount { get; set; }
        public bool AdminBool { get; set; }

        public Security Security { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<Forms> FormsRecipient { get; set; }
        public ICollection<Forms> FormsRecipientId2Navigation { get; set; }
        public ICollection<Forms> FormsRecipientId3Navigation { get; set; }
        public ICollection<Forms> FormsSender { get; set; }
    }
}
