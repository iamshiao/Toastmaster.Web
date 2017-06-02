using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class MemberClub
    {
        public bool IsActive { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime ResumeDate { get; set; }


        [Key, Column(Order = 0)]
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        [Key, Column(Order = 1)]
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}