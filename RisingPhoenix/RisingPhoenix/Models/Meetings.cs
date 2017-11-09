using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RisingPhoenix.Models
{
    public partial class Meetings
    {
        public Meetings()
        {
            Attendance = new HashSet<Attendance>();
        }
        [Key]
        [Required]
        public int MeetingId { get; set; }
        [Required]
        [DisplayName("Meeting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetingDate { get; set; }
        [Required]
        public string Speaker { get; set; }
        
        public ICollection<Attendance> Attendance { get; set; }

    }
}
