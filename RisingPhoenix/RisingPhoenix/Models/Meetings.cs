using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RisingPhoenix.Models
{
    public partial class Meetings
    {
        public int MeetingId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetingDate { get; set; }
        public string Speaker { get; set; }
       

        public Attendance Attendance { get; set; }
    }
}
