using TirileckWorkshop.Data.Enums;

namespace TirileckWorkshop.Data.Dto;

public class OrderDto
{
    public long Id { get; set; }

    public string FIO { get; set; }

    public string? Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string? DeviceName { get; set; }

    public DeviceTypeDto? DeviceType { get; set; }
    public long? DeviceTypeId { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public DateTime StatusDate { get; set; }
    
    public List<StatusHistoryItem> StatusHistory { get; set; }

    public DateTime CreateDate { get; set; }

    public string? TrackCode { get; set; }

    public WorkshopDto Workshop { get; set; }
    public long? WorkshopId { get; set; }
    
    public decimal? SpareCost { get; set; }

    public decimal? AllCost { get; set; }

    public decimal ProfitCost {
        get
        {
            if (AllCost.HasValue && SpareCost.HasValue)
                return AllCost.Value - SpareCost.Value;
            else if (AllCost.HasValue)
                return AllCost.Value;
            else
                return 0;
        }
        set { ProfitCost = value; }
    }
}