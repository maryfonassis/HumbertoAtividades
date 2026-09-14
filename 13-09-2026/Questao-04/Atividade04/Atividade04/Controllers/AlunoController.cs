using Microsoft.AspNetCore.Mvc;
using Atividade04.Models;

namespace Atividade04.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private static List<Aluno> alunos = new List<Aluno>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(alunos);
        }
        [HttpGet("{ra}")]
        public IActionResult Get(string ra)
        {
            var aluno = alunos.FirstOrDefault(a => a.Ra == ra);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (alunos.Any(a => a.Ra == aluno.Ra))
            {
                return BadRequest("Este RA já está cadastrado.");
            }
            alunos.Add(aluno); return Ok(aluno);
        }

        [HttpPut("{ra}")]
        public IActionResult Put(string ra, Aluno alunoAtualizado)
        {
            var aluno = alunos.FirstOrDefault(a => a.Ra == ra); if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            aluno.Nome = alunoAtualizado.Nome;
            aluno.Email = alunoAtualizado.Email;
            aluno.Cpf = alunoAtualizado.Cpf;
            aluno.Ativo = alunoAtualizado.Ativo; return Ok(aluno);
        }

        [HttpDelete("{ra}")]
        public IActionResult Delete(string ra)
        {
            var aluno = alunos.FirstOrDefault(a => a.Ra == ra);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }
            alunos.Remove(aluno); return Ok("Aluno excluído com sucesso.");
        }
    }
}
