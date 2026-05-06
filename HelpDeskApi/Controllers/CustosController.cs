using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskApi.Data;
using HelpDeskApi.Models;

namespace HelpDeskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustosController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: Listar todos os custos (api/Custos)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Custo>>> GetCustos()
        {
            return await _context.Custos.ToListAsync();
        }

        // 2. GET: Buscar um custo específico pelo ID (api/Custos/5)
        [HttpGet("{id}")]
        public async Task<ActionResult<Custo>> GetCusto(int id)
        {
            var custo = await _context.Custos.FindAsync(id);

            if (custo == null)
            {
                return NotFound();
            }

            return custo;
        }

        // 3. POST: Cadastrar um novo custo (api/Custos)
        [HttpPost]
        public async Task<ActionResult<Custo>> PostCusto(Custo custo)
        {
            _context.Custos.Add(custo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCusto), new { id = custo.Id }, custo);
        }

        // 4. PUT: Atualizar um custo existente (api/Custos/5)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCusto(int id, Custo custo)
        {
            if (id != custo.Id)
            {
                return BadRequest("O ID da URL não bate com o ID do corpo da requisição.");
            }

            _context.Entry(custo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // 5. DELETE: Deletar um custo (api/Custos/5)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCusto(int id)
        {
            var custo = await _context.Custos.FindAsync(id);
            if (custo == null)
            {
                return NotFound();
            }

            _context.Custos.Remove(custo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustoExists(int id)
        {
            return _context.Custos.Any(e => e.Id == id);
        }
    }
}