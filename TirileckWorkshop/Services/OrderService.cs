using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TirileckWorkshop.Data;
using TirileckWorkshop.Data.Dto;
using TirileckWorkshop.Data.Enums;
using TirileckWorkshop.Data.Models;

namespace TirileckWorkshop.Services;

public class OrderService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly EmailService _emailService;
    
    public OrderService(
        ApplicationDbContext context,
        IMapper mapper,
        EmailService emailService
    )
    {
        _context = context;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<OrderDto> AddOrder(AddOrderDto order)
    {
        var storageOrder = _mapper.Map<Order>(order);
        storageOrder.CreateDate = DateTime.UtcNow;
        storageOrder.StatusDate = DateTime.UtcNow;
        storageOrder.OrderStatus = OrderStatus.New;
        storageOrder.DeviceTypeId = order.DeviceType?.Id;
        storageOrder.WorkshopId = order.Workshop?.Id;
        storageOrder.DeviceType = null;
        storageOrder.Workshop = null;
        if (storageOrder.DeviceTypeId is not 1)
            storageOrder.DeviceName = null;
        _context.Add(storageOrder);
        await _context.SaveChangesAsync();
        storageOrder.TrackCode = GenerateTrackCode(storageOrder.Id);
        _context.Update(storageOrder);
        await _context.SaveChangesAsync();
        _context.Entry(storageOrder).State = EntityState.Detached;
        var orderDtoWithStatus = await AddOrderStatus(storageOrder.Id, OrderStatus.New);

        if (!string.IsNullOrEmpty(storageOrder.Email))
            await _emailService.SendEmailAsync(storageOrder.Email, "Ремонт",
                $"{storageOrder.FIO}! Ваш заказ создан!\n Трек номер для отслеживания: {storageOrder.TrackCode}");
        
        return orderDtoWithStatus;
    }

    public async Task<OrderDto> AddOrder(AddOrderShortDto order)
    {
        var storageOrder = _mapper.Map<Order>(order);
        storageOrder.CreateDate = DateTime.UtcNow;
        storageOrder.StatusDate = DateTime.UtcNow;
        storageOrder.OrderStatus = OrderStatus.New;
        storageOrder.DeviceTypeId = order.DeviceType?.Id;
        storageOrder.WorkshopId = order.Workshop?.Id;
        storageOrder.DeviceType = null;
        storageOrder.Workshop = null;
        if (storageOrder.DeviceTypeId is not 1)
            storageOrder.DeviceName = null;
        _context.Add(storageOrder);
        await _context.SaveChangesAsync();
        storageOrder.TrackCode = GenerateTrackCode(storageOrder.Id);
        _context.Update(storageOrder);
        await _context.SaveChangesAsync();
        _context.Entry(storageOrder).State = EntityState.Detached;
        var orderDtoWithStatus = await AddOrderStatus(storageOrder.Id, OrderStatus.New);
        
        if (!string.IsNullOrEmpty(storageOrder.Email))
            await _emailService.SendEmailAsync(storageOrder.Email, "Ремонт",
                $"{storageOrder.FIO}! Ваш заказ создан!\n Трек номер для отслеживания: {storageOrder.TrackCode}");
        
        return orderDtoWithStatus;
    }

    public async Task<OrderDto> AddOrderStatus(long storageOrderId, OrderStatus status)
    {
        var order = _context.Orders.Single(x => x.Id == storageOrderId);
        order.OrderStatus = status;
        order.StatusDate = DateTime.UtcNow;
        var orderHistory = string.IsNullOrEmpty(order.StatusHistory)
            ? new List<StatusHistoryItem>()
            : JsonConvert.DeserializeObject<List<StatusHistoryItem>>(order.StatusHistory);
        orderHistory.Add(new StatusHistoryItem()
        {
            Status = order.OrderStatus,
            StatusTime = order.StatusDate
        });
        order.StatusHistory = JsonConvert.SerializeObject(orderHistory);
        _context.Update(order);
        await _context.SaveChangesAsync();
        return _mapper.Map<OrderDto>(order);
    }
    
    public async Task<OrderDto> EditOrder(OrderDto order)
    {
        var storageOrder = await _context.Orders.Where(x => x.Id == order.Id).SingleAsync();
        storageOrder.WorkshopId = order.Workshop.Id;
        storageOrder.AllCost = order.AllCost;
        storageOrder.SpareCost = order.SpareCost;
        _context.Update(storageOrder);
        await _context.SaveChangesAsync();
        _context.Entry(storageOrder).State = EntityState.Detached;
        if (order.OrderStatus != storageOrder.OrderStatus)
        {
            await AddOrderStatus(order.Id, order.OrderStatus);
            if (!string.IsNullOrEmpty(storageOrder.Email))
                await _emailService.SendEmailAsync(storageOrder.Email, "Ремонт",
                    $"{storageOrder.FIO}! У вашего заказа изменился статус!\nНовый статус: {order.OrderStatus.GetName()}");
        }

        return _mapper.Map<OrderDto>(await _context.Orders.Where(x => x.Id == order.Id).SingleAsync());
    }

    public async Task<TrackingOrderDro?> GetTrackedOrder(string trackNumber)
    {
        var findedOrder = await _context.Orders
            .Include(x => x.Workshop)
            .Include(x => x.DeviceType)
            .Where(x => x.TrackCode == trackNumber).FirstOrDefaultAsync();
        if (findedOrder is null)
            return null;
        else
            return _mapper.Map<TrackingOrderDro>(findedOrder);
    }

    public async Task<List<OrderDto>> GetOrders()
    {
        return _mapper.Map<List<OrderDto>>(await _context.Orders
            .Include(x => x.Workshop)
            .Include(x => x.DeviceType)
            .OrderByDescending(x => x.CreateDate).ToListAsync());
    }

    string GenerateTrackCode(long id)
    {
        var trackNumberId = id.ToString();
        var zeroesLength = 10 - trackNumberId.Length;
        var trackNumber = string.Empty;
        foreach (var i in Enumerable.Range(0, zeroesLength))
        {
            trackNumber += "0";
        }

        trackNumber += trackNumberId;
        return trackNumber;
    }
}