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
        [MaxLength(255)]
        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [MaxLength(55)]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNum { get; set; }


        public virtual ICollection<MemberClub> MemberClubs { get; set; }
        public virtual ICollection<SpeechRecord> SpeechRecords { get; set; }
        public virtual ICollection<RoleRecord> RoleRecords { get; set; }
    }
}