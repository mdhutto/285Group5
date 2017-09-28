using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Attendance
    {
        public int MeetingId { get; set; }
        public int MemberId { get; set; }
        public bool AttendBool { get; set; }

        public Meetings Meeting { get; set; }
        public Members Member { get; set; }
    }
}
