using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toastmaster.Web.Console.Models;
using Toastmaster.Web.Console.Models.ViewModels;

namespace Toastmaster.Web.Console.AutoMapper
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<MeetingViewModel, Meeting>()
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubCombobox.SelectedClubId));
        }
    }
}