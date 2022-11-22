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
        
        [HttpGet("{cidade}")]
        public async Task<ActionResult<List<Aluno>>> GetAlunoJson([FromRoute] string cidade)
        {
            var alunos = await _context.TblTeste2                
                .Include(x => x.Details)
                .Where(x => x.Details!.Cidade.Contains(cidade)).ToListAsync();
            return alunos;
        }
    }
}