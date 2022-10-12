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
  [Route("api/vehiculo")]
  public class VehiculoController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public VehiculoController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<VehiculoDTO>>> ObtenerVehiculo()
    {
      try
      {
        return _mapper.Map<List<VehiculoDTO>>(await _context.Vehiculo.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<VehiculoDTO>> ObtenerVehiculoPorId([FromRoute] int id)
    {
      try
      {
        var vehiculo = await _context.Vehiculo.FirstOrDefaultAsync(x => x.Id == id);
        if (vehiculo == null)
        {
          return NotFound();
        }
        return _mapper.Map<VehiculoDTO>(vehiculo);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerVehiculoPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CrearVehiculo([FromForm] VehiculoCreacionDTO vehiculoCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<Vehiculo>(vehiculoCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult> ActualizarHotel(Vehiculo vehiculo, int id)
    {
      try
      {
        if (vehiculo.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Vehiculo.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(vehiculo);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> EliminarVehiculo([FromRoute] int id)
    {
      try
      {
        var hotel = await _context.Vehiculo.FirstOrDefaultAsync(x => x.Id == id);

        if (hotel == null)
        {
          return NotFound();
        }
        _context.Remove(hotel);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}

