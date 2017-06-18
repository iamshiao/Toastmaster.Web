using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models.ViewModels
{
    public class ClubViewModel
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

        public string DisplayText { get; set; }
    }
}