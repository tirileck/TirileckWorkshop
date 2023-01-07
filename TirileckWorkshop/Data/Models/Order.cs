using TirileckWorkshop.Data.Enums;

namespace TirileckWorkshop.Data.Models;

public class Order
{
    public long Id { get; set; }

    public string FIO { get; set; }

    public string? Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string? DeviceName { get; set; }

    public DeviceType? DeviceType { get; set; }
    public long? DeviceTypeId { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public DateTime StatusDate { get; set; }
    
    public string? StatusHistory { get; set; }

    public DateTime CreateDate { get; set; }

    public string? TrackCode { get; set; }

    public Workshop Workshop { get; set; }
    public long? WorkshopId { get; set; }
    
    public decimal? SpareCost { get; set; }

    public decimal? AllCost { get; set; }
}