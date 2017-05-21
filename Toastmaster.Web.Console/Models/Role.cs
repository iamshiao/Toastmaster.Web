using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        [MaxLength(23)]
        public string Abbr { get; set; }

        public virtual ICollection<RoleRecord> RoleRecords { get; set; }
    }
}