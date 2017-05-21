using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public int Seq { get; set; }
        public DateTime HoldDate { get; set; }
        [MaxLength(255)]
        [Required]
        public string Theme { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }
        public virtual ICollection<RoleRecord> RoleRecords { get; set; }
        public virtual ICollection<SpeechRecord> SpeechRecords { get; set; }
    }
}