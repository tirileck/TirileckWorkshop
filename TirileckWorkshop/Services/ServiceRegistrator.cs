using TabBlazor;

namespace TirileckWorkshop.Services;

public static class ServiceRegistrator
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<WorkshopsService>();
        services.AddScoped<DeviceTypeService>();
        services.AddScoped<OrderService>();
        services.AddScoped<UsersService>();
        services.AddScoped<EmailService>();

        services.AddTabler();
    }
}