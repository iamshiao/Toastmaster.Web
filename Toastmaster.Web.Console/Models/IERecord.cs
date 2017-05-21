using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    [Table("IERecord")]
    public class IERecord : RoleRecord
    {
        public int SpeechRecordId { get; set; }
        public virtual SpeechRecord SpeechRecord { get; set; }
    }
}