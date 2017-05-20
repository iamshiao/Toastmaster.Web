using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class SpeechRecord
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public int ProjectSeq { get; set; }
        public string Title { get; set; }

        public int MeetingId { get; set; }
    }
}