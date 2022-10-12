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
  [Route("api/detalle")]
  public class DetalleController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public DetalleController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<DetalleDTO>>> ObtenerDetalle()
    {
      try
      {
        return _mapper.Map<List<DetalleDTO>>(await _context.Detalle.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerDetalle", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<DetalleDTO>> ObtenerDetallePorId([FromRoute] int id)
    {
      try
      {
        var detalle = await _context.Detalle.FirstOrDefaultAsync(x => x.Id == id);
        if (detalle == null)
        {
          return NotFound();
        }
        return _mapper.Map<DetalleDTO>(detalle);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerDetallePorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CrearDetalle([FromForm] DetalleCreacionDTO detalleCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<Detalle>(detalleCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearDetalle", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult> ActualizarDetalle(Detalle detalle, int id)
    {
      try
      {
        if (detalle.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Detalle.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(detalle);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarDetalle", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> EliminarDetalle([FromRoute] int id)
    {
      try
      {
        var detalle = await _context.Detalle.FirstOrDefaultAsync(x => x.Id == id);

        if (detalle == null)
        {
          return NotFound();
        }
        _context.Remove(detalle);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarDetalle", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}

