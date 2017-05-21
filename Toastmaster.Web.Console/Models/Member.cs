using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class Member
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        [MaxLength(63)]
        [Required]
        public string EngFirstName { get; set; }
        [MaxLength(63)]
        [Required]
        public string EngLastName { get; set; }
        [MaxLength(1023)]
        [Required]
        public string Mail { get; set; }
        [MaxLength(55)]
        public string PhoneNum { get; set; }
        public bool IsActive { get; set; }
        public bool IsGuest { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<SpeechRecord> SpeechRecords { get; set; }
        public virtual ICollection<RoleRecord> RoleRecords { get; set; }
    }
}