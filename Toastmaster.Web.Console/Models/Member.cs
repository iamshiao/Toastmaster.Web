using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EngFirstName { get; set; }
        public string EngLastName { get; set; }
        public string Mail { get; set; }
        public string PhoneNum { get; set; }
        public bool IsActive { get; set; }
        public bool IsGuest { get; set; }

        public int ClubId { get; set; }
    }
}