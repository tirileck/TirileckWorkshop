using TirileckWorkshop.Data.Enums;

namespace TirileckWorkshop.Data.Dto;

public class TrackingOrderDro
{
    public string FIO { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string DeviceTypeName { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public DateTime StatusDate { get; set; }
    public List<StatusHistoryItem> StatusHistory { get; set; }

    public DateTime CreateDate { get; set; }

    public string? TrackCode { get; set; }

    public string WorkshopAddress { get; set; }
}