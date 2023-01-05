using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TirileckWorkshop.Data;
using TirileckWorkshop.Data.Dto;

namespace TirileckWorkshop.Services;

public class WorkshopsService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public WorkshopsService(
        ApplicationDbContext context,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WorkshopDto>> GetWorkshops()
    {
        var workshops = await _context.WorkShops.ToListAsync();
        return _mapper.Map<List<WorkshopDto>>(workshops);
    }
}