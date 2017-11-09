using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RisingPhoenix.Models
{
    public partial class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [Required]
        public int MeetingId { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public bool AbsenceBool { get; set; }

        [ForeignKey(nameof(MeetingId))]
        public Meetings Meeting { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Members Member { get; set; }
    }
}
