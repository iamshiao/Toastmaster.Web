using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(63)]
        public string EngFirstName { get; set; }

        [Required]
        [MaxLength(63)]
        public string EngLastName { get; set; }

        [Required]
        [MaxLength(1023)]
        [Index(IsUnique = true)]
        public string Mail { get; set; }

        [MaxLength(55)]
        public string PhoneNum { get; set; }

        public bool IsActive { get; set; }


        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<SpeechRecord> SpeechRecords { get; set; }
        public virtual ICollection<RoleRecord> RoleRecords { get; set; }
    }
}