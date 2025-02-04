using AutoMapper;
using CleanDesign.Core.DTOs;
using CleanDesign.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.Mapping
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
