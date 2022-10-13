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
  [Route("api/tipodocumento")]
  public class TipoDocumentoController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public TipoDocumentoController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<List<TipoDocumentoDTO>>> ObtenerTipoDocumento()
    {
      try
      {
        return _mapper.Map<List<TipoDocumentoDTO>>(await _context.TipoDocumento.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("TipoDocumento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<TipoDocumentoDTO>> ObtenerTipoDocumentoPorId([FromRoute] int id)
    {
      try
      {
        var tipoDocumento = await _context.TipoDocumento.FirstOrDefaultAsync(x => x.Id == id);
        if (tipoDocumento == null)
        {
          return NotFound();
        }
        return _mapper.Map<TipoDocumentoDTO>(tipoDocumento);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerTipoDocumentoPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> TipoDocumentoSucursal([FromForm] TipoDocumentoCreacionDTO tipoDocumentoCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<TipoDocumento>(tipoDocumentoCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearTipoDocumento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> ActualizarTipoDocumento(TipoDocumento tipoDocumento, int id)
    {
      try
      {
        if (tipoDocumento.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.TipoDocumento.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(tipoDocumento);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarTipoDocumento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> EliminarTipoDocumento([FromRoute] int id)
    {
      try
      {
        var tipoDocumento = await _context.TipoDocumento.FirstOrDefaultAsync(x => x.Id == id);

        if (tipoDocumento == null)
        {
          return NotFound();
        }
        _context.Remove(tipoDocumento);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarTipoDocumento", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}
