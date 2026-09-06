using Microsoft.AspNetCore.Mvc;
using Atividade26_09.Models;
using System.Xml.Linq;

namespace Atividade26_09.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();


        [HttpPost]
        public IActionResult AdicionarPessoa(Pessoa pessoa)
        {
            if (pessoas.Any(p => p.CPF == pessoa.CPF))
            {
                return BadRequest("Já existe uma pessoa cadastrada com esse CPF");
            }

            pessoas.Add(pessoa);

            return Ok(pessoa);
        }


        [HttpPut("{cpf}")]
        public IActionResult AtualizarPessoa(string cpf, Pessoa pessoaAtualizada)
        {
            Pessoa? pessoa = pessoas.FirstOrDefault(p => p.CPF == cpf);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Peso = pessoaAtualizada.Peso;
            pessoa.Altura = pessoaAtualizada.Altura;

            return Ok(pessoa);
        }

        [HttpDelete("{cpf}")]
        public IActionResult RemoverPessoa(string cpf)
        {
            Pessoa? pessoa = pessoas.FirstOrDefault(p => p.CPF == cpf);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            pessoas.Remove(pessoa);

            return Ok("Pessoa removida com sucesso.");
        }


        [HttpGet]
        public IActionResult BuscarTodas()
        {
            return Ok(pessoas);
        }


        [HttpGet("cpf/{cpf}")]
        public IActionResult BuscarPorCPF(string cpf)
        {
            Pessoa? pessoa = pessoas.FirstOrDefault(p => p.CPF == cpf);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            return Ok(pessoa);
        }


        [HttpGet("imc")]
        public IActionResult BuscarPorIMC()
        {
            var pessoasComIMCBom = pessoas.Where(p =>
            {
                double imc = p.Peso / (p.Altura * p.Altura);

                return imc >= 18 && imc <= 24;
            }).ToList();

            return Ok(pessoasComIMCBom);
        }


        [HttpGet("nome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = pessoas
                .Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultado.Count == 0)
            {
                return NotFound("Nenhuma pessoa encontrada com esse nome.");
            }

            return Ok(resultado);
        }
    }
}