using TabBlazor;
using Tabler.Docs;

namespace TirileckWorkshop.Data.Enums;

public enum OrderStatus
{
    New = 1,            // Желтый
    InProgress,         // Синий
    InWork,             // Оранж
    Succeed,            // Зеленый
    Cancelled           // Красныцй
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

    public static IIconType GetIcon(this OrderStatus status) => status switch
    {
        OrderStatus.New => TablerIcons.Abc,
        OrderStatus.InProgress => TablerIcons.Bike,
        OrderStatus.InWork => TablerIcons.Bike_fast,
        OrderStatus.Succeed => TablerIcons.Check,
        OrderStatus.Cancelled => TablerIcons.Close_circle_outline,
        _ => throw new ArgumentException("Invalid status")
    };

    public static TablerColor GetColor(this OrderStatus status) => status switch
    {
        OrderStatus.New => TablerColor.Yellow,
        OrderStatus.InProgress => TablerColor.Blue,
        OrderStatus.InWork => TablerColor.Orange,
        OrderStatus.Succeed => TablerColor.Success,
        OrderStatus.Cancelled => TablerColor.Danger,
        _ => throw new ArgumentException("Invalid status")
    };

    public static string GetSubtext(this OrderStatus status) => status switch
    {
        OrderStatus.New => "Мы получили вашу заявку, скоро с вами свяжется специалист",
        OrderStatus.InProgress => "Мы обрабатываем вашу заявку",
        OrderStatus.InWork => "Работа кипит...",
        OrderStatus.Succeed => "Ваш заказ выполнен! Обращайтесь к нам еще:)",
        OrderStatus.Cancelled => "Ваш заказ отменен! Надеемся, в следующий раз сможем помочь:)",
        _ => throw new ArgumentException("Invalid status")
    };
    
    
}