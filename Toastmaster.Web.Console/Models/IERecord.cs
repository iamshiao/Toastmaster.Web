using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class IERecord
    {
        public int SpeechRecordId { get; set; }
        public int RoleRecordId { get; set; }

        public SpeechRecord SpeechRecord { get; set; }
        public RoleRecord RoleRecord { get; set; }
    }
}