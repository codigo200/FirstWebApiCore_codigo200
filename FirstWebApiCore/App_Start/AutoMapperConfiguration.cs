using AutoMapper;
using FirstWebApiCore.Domain.Entities;
using FirstWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApiCore.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void LoadProfiles()
        {
            Mapper.Initialize(
                cf => cf.CreateMap<Contact, ContactModel>().ReverseMap()
            );
        }
    }
}
