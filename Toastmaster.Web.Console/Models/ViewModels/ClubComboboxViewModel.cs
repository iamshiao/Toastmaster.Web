using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.Models.ViewModels
{
    public class ClubComboboxViewModel
    {
        public IEnumerable<ClubViewModel> Clubs { get; set; }

        public string SelectedClubId { get; set; }
    }
}