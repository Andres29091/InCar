using AutoMapper;
using InCar.Data;
using InCar.DTOs;
using InCar.Entidades;
using InCar.Servicios.IlogService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InCar.Controllers
{
  [ApiController]
  [Route("api/TipoVehiculo")]
  public class TipoVehiculoController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public TipoVehiculoController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<List<TipoVehiculoDTO>>> ObtenerTipoVehiculo()
    {
      try
      {
        return _mapper.Map<List<TipoVehiculoDTO>>(await _context.TipoVehiculo.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerTipoVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<TipoVehiculoDTO>> ObtenerTipoVehiculoPorId([FromRoute] int id)
    {
      try
      {
        var tipovehiculo = await _context.TipoVehiculo.FirstOrDefaultAsync(x => x.Id == id);
        if (tipovehiculo == null)
        {
          return NotFound();
        }
        return _mapper.Map<TipoVehiculoDTO>(tipovehiculo);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerTipoVehiculoPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> CrearTipoVehiculo([FromForm] TipoVehiculoCreacionDTO tipovehiculoCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<TipoVehiculo>(tipovehiculoCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearTipoVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> ActualizarTipoVehiculo(TipoVehiculo tipovehiculo, int id)
    {
      try
      {
        if (tipovehiculo.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.TipoVehiculo.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(tipovehiculo);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarTipoVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> EliminarTipoVehiculo([FromRoute] int id)
    {
      try
      {
        var tipoVehiculo = await _context.TipoVehiculo.FirstOrDefaultAsync(x => x.Id == id);

        if (tipoVehiculo == null)
        {
          return NotFound();
        }
        _context.Remove(tipoVehiculo);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarTipoVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}

