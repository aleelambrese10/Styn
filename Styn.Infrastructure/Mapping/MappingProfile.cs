using Styn.Domain.DTOs;
using Styn.Domain.Entities;
using AutoMapper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {


        CreateMap<UserDTO, ApplicationUser>().ReverseMap();





    }
}

