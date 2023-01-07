using AutoMapper;
using Newtonsoft.Json;
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
            .ForMember(x => x.WorkshopAddress, x => x.MapFrom(x => x.Workshop.Address))
            .ForMember(dst => dst.StatusHistory, conf =>
                conf.MapFrom(src =>
                    string.IsNullOrEmpty(src.StatusHistory)
                        ? new List<StatusHistoryItem>()
                        : JsonConvert.DeserializeObject<List<StatusHistoryItem>>(src.StatusHistory)));

        CreateMap<Order, OrderDto>()
            .ForMember(dst => dst.StatusHistory, conf =>
                conf.MapFrom(src =>
                    string.IsNullOrEmpty(src.StatusHistory)
                        ? new List<StatusHistoryItem>()
                        : JsonConvert.DeserializeObject<List<StatusHistoryItem>>(src.StatusHistory)));
        
        CreateMap<OrderDto, Order>()
            .ForMember(dst => dst.StatusHistory, conf =>
                conf.MapFrom(src => JsonConvert.SerializeObject(src.StatusHistory)));

        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, AddUserDto>().ReverseMap();
    }
}