namespace TirileckWorkshop.Data.Enums;

public enum OrderStatus
{
    New = 1,
    InProgress,
    InWork,
    Succeed,
    Cancelled
}

public static class OrderStatusesExtension
{
    public static string GetName(this OrderStatus status) => status switch
    {
        OrderStatus.New => "Новый",
        OrderStatus.InProgress => "В обработке",
        OrderStatus.InWork => "В работе",
        OrderStatus.Succeed => "Выполнен",
        OrderStatus.Cancelled => "Отклонен",
        _ => "Error"
    };
}