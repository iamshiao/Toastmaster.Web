using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class ClubMember
    {
        public int ClubId { get; set; }
        public int MemberId { get; set; }
        public Club Club { get; set; }
        public Member Member { get; set; }
    }
}