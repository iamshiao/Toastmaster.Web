using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toastmaster.Web.Console.Models;
using Toastmaster.Web.Console.Models.ViewModels;

namespace Toastmaster.Web.Console.AutoMapper
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<ClubViewModel, Club>();
            CreateMap<Club, ClubViewModel>()
                .ForMember(dest => dest.DisplayText, opt => opt.ResolveUsing(src =>
                {
                    if (string.IsNullOrEmpty(src.ChineseAbbr))
                    {
                        return $"{src.Name}({src.Abbr})";
                    }
                    else
                    {
                        return $"{src.ChineseAbbr}({src.Abbr})";
                    }
                }));
        }
    }
}