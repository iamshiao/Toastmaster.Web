using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models.ViewModels
{
    public class MeetingViewModel
    {
        public MeetingViewModel()
        {
            HoldDate = DateTime.Now;
            Seq = 1;
        }

        public int Id { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Seq { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime HoldDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string Theme { get; set; }

        public int ClubId { get; set; }
        public ClubViewModel Club { get; set; }

        public ClubComboboxViewModel ClubCombobox { get; set; }
    }
}