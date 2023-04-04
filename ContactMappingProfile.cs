using AutoMapper;
using ContactAPI.Entities;
using ContactAPI.Models;

namespace ContactAPI
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile() 
        {

            CreateMap<Contact,ContactDto>()
                .ForMember(e => e.Role, c => c.MapFrom(s => s.Role.Name));
                
        }
    }
}
