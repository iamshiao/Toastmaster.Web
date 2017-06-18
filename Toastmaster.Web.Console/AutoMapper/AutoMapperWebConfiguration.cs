using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toastmaster.Web.Console.AutoMapper
{
    public class AutoMapperWebConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MeetingProfile());
                cfg.AddProfile(new ClubProfile());
            });
        }
    }
}