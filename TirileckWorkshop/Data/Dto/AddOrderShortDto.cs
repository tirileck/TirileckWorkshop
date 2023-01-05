namespace TirileckWorkshop.Data.Dto;

public class AddOrderShortDto
{
    public string FIO { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string DeviceName { get; set; }

    public long? DeviceTypeId { get; set; }

    public long? WorkshopId { get; set; }
}