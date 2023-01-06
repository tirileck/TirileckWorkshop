using TirileckWorkshop.Data.Enums;

namespace TirileckWorkshop.Data.Dto;

public class StatusHistoryItem
{
    public OrderStatus Status { get; set; }
    public DateTime StatusTime { get; set; }
}