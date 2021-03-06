﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class Club
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [MaxLength(23)]
        public string Abbr { get; set; }

        [MaxLength(23)]
        public string ChineseAbbr { get; set; }


        public virtual ICollection<MemberClub> MemberClubs { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}