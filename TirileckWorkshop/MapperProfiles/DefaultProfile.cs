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
        CreateMap<Order, TrackingOrderDro>()
            .ForMember(x => x.DeviceTypeName,
                x => x.MapFrom(x => string.IsNullOrEmpty(x.DeviceName) ? x.DeviceType.Name : x.DeviceName)
            )
            .ForMember(x => x.WorkshopAddress, x => x.MapFrom(x => x.Workshop.Address));
    }
}