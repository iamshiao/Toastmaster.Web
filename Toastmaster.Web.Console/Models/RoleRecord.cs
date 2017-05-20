﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class RoleRecord
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int MemberId { get; set; }
        public int MeetingId { get; set; }
        public int RoleId { get; set; }
    }
}