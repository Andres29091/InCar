using AutoMapper;
using InCar.Data;
using InCar.DTOs;
using InCar.Entidades;
using InCar.Servicios.IlogService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InCar.Controllers
{
  [ApiController]
  [Route("api/historial")]
  public class HistorialController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public HistorialController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<HistorialDTO>>> ObtenerHistorial()
    {
      try
      {
        return _mapper.Map<List<HistorialDTO>>(await _context.Historial.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerHistorial", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<HistorialDTO>> ObtenerHistorialPorId([FromRoute] int id)
    {
      try
      {
        var historial = await _context.Historial.FirstOrDefaultAsync(x => x.Id == id);
        if (historial == null)
        {
          return NotFound();
        }
        return _mapper.Map<HistorialDTO>(historial);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerDetallePorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CrearHistorial([FromForm] HistorialCreacionDTO historialCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<Historial>(historialCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearHistorial", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult> ActualizarHistorial(Historial historial, int id)
    {
      try
      {
        if (historial.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Historial.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(historial);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarHistorial", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> EliminarHistorial([FromRoute] int id)
    {
      try
      {
        var historial = await _context.Historial.FirstOrDefaultAsync(x => x.Id == id);

        if (historial == null)
        {
          return NotFound();
        }
        _context.Remove(historial);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarHistorial", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}

