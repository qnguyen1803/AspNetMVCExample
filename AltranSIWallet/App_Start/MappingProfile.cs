using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto.Consultant;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain To Dto
            CreateMap<Consultant, ConsultantReturnDto>();
            CreateMap<ConsultantReturnDto, Consultant>();
        }
    }
}