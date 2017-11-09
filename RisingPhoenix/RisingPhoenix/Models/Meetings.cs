using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RisingPhoenix.Models
{
    public partial class Meetings
    {    [Key]
        public int MeetingId { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Speaker { get; set; }
       

        public Attendance Attendance { get; set; }
    }
}
