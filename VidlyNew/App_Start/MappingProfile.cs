﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyNew.Dtos;
using VidlyNew.Models;

namespace VidlyNew.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Customer, CustomerDto>();  
                 
            Mapper.CreateMap<MembershipType, MembershipDto>();

            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<Genre, GenreDto>();

            //If you want to assign id prop and want to avoid exception
            //CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());
            //CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}