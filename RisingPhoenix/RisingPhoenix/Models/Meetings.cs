using System;
using System.Collections.Generic;

namespace RisingPhoenix.Models
{
    public partial class Meetings
    {
        public int MeetingId { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Speaker { get; set; }

        public Attendance Attendance { get; set; }
    }
}
