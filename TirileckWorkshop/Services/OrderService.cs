using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TirileckWorkshop.Data;
using TirileckWorkshop.Data.Dto;
using TirileckWorkshop.Data.Enums;
using TirileckWorkshop.Data.Models;

namespace TirileckWorkshop.Services;

public class OrderService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public OrderService(
        ApplicationDbContext context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddOrder(AddOrderShortDto order)
    {
        var storageOrder = _mapper.Map<Order>(order);
        storageOrder.CreateDate = DateTime.UtcNow;
        storageOrder.StatusDate = DateTime.UtcNow;
        storageOrder.OrderStatus = OrderStatus.New;
        storageOrder.TrackCode = Guid.NewGuid();
        if (storageOrder.DeviceTypeId is not 1)
            storageOrder.DeviceName = null;
        _context.Add(storageOrder);
        await _context.SaveChangesAsync();
    }

    public async Task<TrackingOrderDro?> GetTrackedOrder(Guid trackNumber)
    {
        var findedOrder = await _context.Orders.Where(x => x.TrackCode == trackNumber).FirstOrDefaultAsync();
        if (findedOrder is null)
            return null;
        else
            return _mapper.Map<TrackingOrderDro>(findedOrder);
    }
}