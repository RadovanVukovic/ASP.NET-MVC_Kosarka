using AutoMapper;
using RVAS_Kosarka.Dtos;
using RVAS_Kosarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVAS_Kosarka.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Club, ClubDto>();
            Mapper.CreateMap<ClubDto, Club>();
        }
    }
}