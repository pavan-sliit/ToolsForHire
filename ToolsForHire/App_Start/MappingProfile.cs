using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToolsForHire.Models;
using ToolsForHire.Dtos;

namespace ToolsForHire.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Tool, ToolDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<CategoryType, CategoryTypeDto>();

            //dto to domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<ToolDto, Tool>()
                .ForMember(t => t.Id, opt => opt.Ignore());
        }
    }
}