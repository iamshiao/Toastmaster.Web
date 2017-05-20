using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Toastmaster.Web.Console.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UsrName { get; set; }
        public string Password { get; set; }

        public int ClubId { get; set; }
    }
}