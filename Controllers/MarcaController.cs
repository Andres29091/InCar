using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InCar.Data;
using InCar.DTOs;
using InCar.Entidades;
using InCar.Servicios.IlogService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace InCar.Controllers
{
  [ApiController]
  [Route("api/marca")]
  public class MarcaController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;

    public MarcaController(IMapper mapper, ApplicationDbContext context, ILogService logService)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
    }

    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<List<MarcaDTO>>> ObtenerMarca()
    {
      try
      {
        return _mapper.Map<List<MarcaDTO>>(await _context.Marca.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerMarca", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<MarcaDTO>> ObtenerMarcaPorId([FromRoute] int id)
    {
      try
      {
        var marca = await _context.Marca.FirstOrDefaultAsync(x => x.Id == id);
        if (marca == null)
        {
          return NotFound();
        }
        return _mapper.Map<MarcaDTO>(marca);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerMarcaPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> CrearMarca([FromForm] MarcaCreacionDTO marcaCreacionDTO)
    {
      try
      {
        _context.Add(_mapper.Map<Marca>(marcaCreacionDTO));
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearMarca", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> ActualizarMarca(Marca marca, int id)
    {
      try
      {
        if (marca.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Marca.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(marca);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarMarca", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> EliminarMarca([FromRoute] int id)
    {
      try
      {
        var hotel = await _context.Marca.FirstOrDefaultAsync(x => x.Id == id);

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
        _logService.WriteEventLog("EliminarMarca", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}

