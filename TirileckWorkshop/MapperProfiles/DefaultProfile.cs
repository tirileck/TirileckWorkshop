using AutoMapper;
using TirileckWorkshop.Data.Dto;
using TirileckWorkshop.Data.Models;

namespace TirileckWorkshop.MapperProfiles;

public class DefaultProfile : Profile
{
    public DefaultProfile()
    {
        CreateMap<Workshop, WorkshopDto>().ReverseMap();
        CreateMap<DeviceTypeDto, DeviceType>().ReverseMap();
        CreateMap<AddOrderShortDto, Order>();
    }
}