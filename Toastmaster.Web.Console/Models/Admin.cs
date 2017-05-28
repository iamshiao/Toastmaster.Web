using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toastmaster.Web.Console.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string UsrName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}