using BlazorAppJsonColumns.Server.Data;
using BlazorAppJsonColumns.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppJsonColumns.Server.Controllers
{
    [Route("v0/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        public AlunoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("createaluno")]
        public async Task<IActionResult> AddAluno([FromBody] List<Aluno> alunos)
        {
            await _context.TblTeste2.AddRangeAsync(alunos);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, alunos);
        }

        [HttpGet("{cidade1}")]
        public async Task<ActionResult<List<Aluno>>> GetAlunos([FromRoute] string cidade1)
        {
            var alunos = await _context.TblTeste2
                .Include(x => x.Details)
                .Where(x => x.Details!.Cidade.Contains(cidade1)).ToListAsync();
            return Ok(alunos);
        }

        [HttpGet("todosalunos")]
        public async Task<ActionResult<List<Aluno>>> GetTodoAlunos()
        {
            return await _context.TblTeste2.ToListAsync();
        }
    }
}