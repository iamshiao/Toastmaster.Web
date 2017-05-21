using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toastmaster.Web.Console.Models
{
    public class ClubMember
    {
        [Key]
        [Column(Order = 1)]
        public int ClubId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int MemberId { get; set; }
        public Club Club { get; set; }
        public Member Member { get; set; }
    }
}