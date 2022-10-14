using AutoMapper;
using InCar.Data;
using InCar.DTOs;
using InCar.Entidades;
using InCar.Servicios;
using InCar.Servicios.IlogService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InCar.Controllers
{
  [ApiController]
  [Route("api/imagenvehiculo")]
  public class ImagenVehiculoController : Controller
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILogService _logService;
    private readonly IAlmacenadorArchivos _almacenadorArchivos;
    private readonly string contenedor = "Files";

    public ImagenVehiculoController(IMapper mapper, ApplicationDbContext context, ILogService logService, IAlmacenadorArchivos almacenadorArchivos)
    {
      this._mapper = mapper;
      this._context = context;
      this._logService = logService;
      this._almacenadorArchivos = almacenadorArchivos;
    }

    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<List<ImagenVehiculoDTO>>> ObtenerImagenVehiculo()
    {
      try
      {
        return _mapper.Map<List<ImagenVehiculoDTO>>(await _context.ImagenVehiculo.ToListAsync());
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerImagenVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpGet("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult<ImagenVehiculoDTO>> ObtenerImagenVehiculoPorId([FromRoute] int id)
    {
      try
      {
        var imagenvehiculo = await _context.ImagenVehiculo.FirstOrDefaultAsync(x => x.Id == id);
        if (imagenvehiculo == null)
        {
          return NotFound();
        }
        return _mapper.Map<ImagenVehiculoDTO>(imagenvehiculo);
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ObtenerImagenVehiculoPorId", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> CrearImagenVehiculo([FromForm] ImagenVehiculoDTO imagenVehiculoDTO)
    {
      try
      {
        var archivos = _mapper.Map<ImagenVehiculo>(imagenVehiculoDTO);
        if (imagenVehiculoDTO.Foto != null)
        {
          archivos.Foto = await _almacenadorArchivos.GuardarArchivo(contenedor, imagenVehiculoDTO.Foto);
        }
        _context.Add(archivos);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("CrearImagenVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpPut("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> ActualizarImagenVehiculo(ImagenVehiculo imagenVehiculo, int id)
    {
      try
      {
        if (imagenVehiculo.Id != id)
        {
          return BadRequest("El registro no existe");
        }
        var existe = await _context.Historial.AnyAsync(x => x.Id == id);

        if (!existe)
        {
          return NotFound();
        }

        _context.Update(imagenVehiculo);
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("ActualizarImagenVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }

    [HttpDelete("[action]/{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public async Task<ActionResult> EliminarImagenVehiculo([FromRoute] int id)
    {
      try
      {
        var imagenVehiculo = await _context.ImagenVehiculo.FirstOrDefaultAsync(x => x.Id == id);

        if (imagenVehiculo == null)
        {
          return NotFound();
        }
        _context.Remove(imagenVehiculo);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        _logService.WriteEventLog("EliminarImagenVehiculo", GetType().Name, ex.Message, "error");
        return BadRequest();
      }
    }
  }
}
