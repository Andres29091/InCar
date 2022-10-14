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
  [Route("api/procedimiento")]
  public class ProcedimientoController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public ProcedimientoController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<List<ProcedimientoDTO>>> ObtenerProcedimiento()
    {
      try
      {
        return _mapper.Map<List<ProcedimientoDTO>>(await _context.Procedimiento.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerProcedimiento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<ProcedimientoDTO>> ObtenerProcedimientoPorId([FromRoute] int id)
    {
      try
      {
        var procedimiento = await _context.Procedimiento.FirstOrDefaultAsync(x => x.Id == id);
        if (procedimiento == null)
        {
          return NotFound();
        }
        return _mapper.Map<ProcedimientoDTO>(procedimiento);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerProcedimientoPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> CrearProcedimiento([FromBody] ProcedimientoCreacionDTO procedimientoCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<Procedimiento>(procedimientoCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearProcedimiento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> ActualizarProcedimiento(Procedimiento procedimiento, int id)
    {
      try
      {
        if (procedimiento.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Procedimiento.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(procedimiento);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarProcedimiento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> EliminarProcedimiento([FromRoute] int id)
    {
      try
      {
        var procedimiento = await _context.Procedimiento.FirstOrDefaultAsync(x => x.Id == id);

        if (procedimiento == null)
        {
          return NotFound();
        }
        _context.Remove(procedimiento);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarProcedimiento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}
