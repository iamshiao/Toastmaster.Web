using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class SpeechRecord
    {
        public int Id { get; set; }
        [MaxLength(63)]
        [Required]
        public string Project { get; set; }
        public int ProjectSeq { get; set; }
        [MaxLength(127)]
        [Required]
        public string Title { get; set; }

        public int MemberId { get; set; }
        public int MeetingId { get; set; }
        public Member Member { get; set; }
        public Meeting Meeting { get; set; }
    }
}