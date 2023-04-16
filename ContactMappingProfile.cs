using AutoMapper;
using ContactAPI.Entities;
using ContactAPI.Models;

namespace ContactAPI
{
    //Mapowanie modeli
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile() 
        {

            CreateMap<Contact,ContactDto>()
                .ForMember(e => e.Role, c => c.MapFrom(s => s.Role.Name));

            CreateMap<Contact, ContactAutorizedDto>()
                .ForMember(e => e.Role, c => c.MapFrom(s => s.Role.Name))
                .ForMember(e => e.RoleId, c => c.MapFrom(s => s.Role.Id));
                //.ForMember(e => e.DateOfBirth, c => c.MapFrom(s => s.DateOfBirth.ToString()));

        }
    }
}
