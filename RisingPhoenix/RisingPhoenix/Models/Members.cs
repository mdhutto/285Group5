using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RisingPhoenix.Models
{
    public partial class Members
    { 
        public Members()
        {
            Attendance = new HashSet<Attendance>();
            FormsRecipient = new HashSet<Forms>();
            FormsSender = new HashSet<Forms>();
            Security = new HashSet<Security>();
        }
        [Key]
        public int MemberId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Url)]
        public string Website { get; set; }
        [Required]
        [DisplayName("Member Since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MemberSince { get; set; }
        [Required]
        [DisplayName("Absence Count")]
        public int AbsenceCount { get; set; }
        [Required]
        [DisplayName("Check this box if this member should be an administrator.")]
        public bool AdminBool { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }


        // SR: Trying to get the data/report page working
        [DisplayName("Referrals Recieved")]
        public int frec { get; set; }
        [DisplayName("Referrals Sent")]
        public int fsent { get; set; }
        [DisplayName("Income Generated")]
        public decimal? fincome { get; set; }
        [DisplayName("Face to Faces")]
        public int ff2f { get; set; }

        //public Security Security { get; set; }

        public ICollection<Security> Security { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<Forms> FormsRecipient { get; set; }
        public ICollection<Forms> FormsSender { get; set; }
    }
}
