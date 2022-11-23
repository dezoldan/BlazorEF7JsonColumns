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

        [HttpGet("todosalunos")]
        public async Task<ActionResult<List<Aluno>>> GetTodoAlunos()
        {
            return await _context.TblTeste2.ToListAsync();
        }

        // Vídeo dia 21/11/22
        [HttpPost("createaluno")]
        public async Task<IActionResult> AddAluno([FromBody] List<Aluno> alunos)
        {
            await _context.TblTeste2.AddRangeAsync(alunos);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, alunos);
        }

        // Vídeo dia 22/11/22
        [HttpGet("{cidade1}")]
        public async Task<ActionResult<List<Aluno>>> GetAlunos([FromRoute] string cidade1)
        {
            var alunos = await _context.TblTeste2
                .Include(x => x.Details)
                .Where(x => x.Details!.Cidade.Contains(cidade1)).ToListAsync();
            return Ok(alunos);
        }

        // Vídeo dia 23/11/22.
        [HttpGet("{id}/{newcidade}")]
        public async Task<ActionResult<int>> UpdateAluno1([FromRoute] int id, string newcidade)
        {
            var aluno1 = await _context.TblTeste2.Where(x=> x.Id== id).FirstOrDefaultAsync();
            if (aluno1 != null)
            {
                aluno1.Details!.Cidade = newcidade;
                _context.Entry(aluno1).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(aluno1.Id);
            }
            else return null!;
        }

        // Vídeo dia 23/11/22.
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateAluno2(
            [FromRoute] int id, [FromBody] Aluno aluno1)
        {
            var aluno2 = await _context.TblTeste2.Where(x => x.Id== id).FirstOrDefaultAsync();
            if (aluno2 != null)
            {
                aluno2.Id = aluno1.Id;
                aluno2.Nome = aluno1.Nome;
                aluno2.Sobrenome = aluno1.Sobrenome;
                aluno2.Details = new AlunoDetails()
                {
                    Cidade = aluno1.Details!.Cidade,
                    Idade = aluno1.Details.Idade,
                    Rua = aluno1.Details.Rua
                };
                await _context.SaveChangesAsync();
                return Ok(aluno2.Id);
            }
            else return NotFound();
        }

    }
}