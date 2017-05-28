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

        [Required]
        [MaxLength(63)]
        public string Project { get; set; }

        public int ProjectSeq { get; set; }

        [Required]
        [MaxLength(127)]
        public string Title { get; set; }


        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}