using ClientesApi.Datos;
using ClientesApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("linq")]
        public async Task<ActionResult<IEnumerable<object>>> GetClientesViaLinq(int page = 1, int pageSize = 5)
        {
            var clientes = await _context.Clientes
                .Include(c => c.Pais)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    c.Telefono,
                    Pais = c.Pais != null ? c.Pais.Nombre : ""
                })
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("sp")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesViaSP(int page = 1, int pageSize = 5)
        {
            var clientes = await _context.Set<ClienteDTO>()
                .FromSqlRaw("EXEC sp_ObtenerClientesPaginados @Page = {0}, @PageSize = {1}", page, pageSize)
                .ToListAsync();

            return Ok(clientes);
        }
    }
}
