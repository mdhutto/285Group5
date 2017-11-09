using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RisingPhoenix.Models
{
    public partial class Attendance
    {
        [Key]
        public int MeetingId { get; set; }
        public int MemberId { get; set; }
        public bool AbsenceBool { get; set; }

        public Meetings Meeting { get; set; }
        public Members Member { get; set; }
    }
}
