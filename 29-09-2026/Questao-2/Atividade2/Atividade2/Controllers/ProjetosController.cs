using Atividade2.Models;
using Atividade2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atividade2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : Controller
    {
        private readonly IProjetoRepository projetoRepository;

        public ProjetosController(IProjetoRepository projetoRepository)
        {
            this.projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var projetos = projetoRepository.Listar();

            return Ok(projetos);
        }

        [HttpPost]
        public IActionResult Adicionar(Projeto projeto)
        {
            var adicionado = projetoRepository.Adicionar(projeto);

            if (!adicionado)
            {
                return Conflict("Já existe um projeto com esse número.");
            }

            return Created("", projeto);
        }

    }
}
