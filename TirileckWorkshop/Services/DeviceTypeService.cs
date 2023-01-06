using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TirileckWorkshop.Data;
using TirileckWorkshop.Data.Dto;

namespace TirileckWorkshop.Services;

public class DeviceTypeService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public DeviceTypeService(
        ApplicationDbContext context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DeviceTypeDto>> GetDeviceTypes()
    {
        var workshops = await _context.DeviceTypes.ToListAsync();
        return _mapper.Map<List<DeviceTypeDto>>(workshops);
    }
}