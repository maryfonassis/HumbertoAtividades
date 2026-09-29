using Atividade2.Models;
using Atividade2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atividade2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitasController : Controller
    {
        private readonly IVisitaRepository visitaRepository;
        private readonly IProjetoRepository projetoRepository;

        public VisitasController(
            IVisitaRepository visitaRepository,
            IProjetoRepository projetoRepository)
        {
            this.visitaRepository = visitaRepository;
            this.projetoRepository = projetoRepository;
        }

        [HttpPost]
        public IActionResult Registrar(Visita visita)
        {
            var projeto = projetoRepository.BuscarPorNumero(visita.NumeroProjeto);

            if (projeto == null)
            {
                return NotFound("Projeto não encontrado.");
            }

            visita.DataVisita = DateTime.Now;

            visitaRepository.Adicionar(visita);

            return Created("", visita);
        }

        [HttpGet("{numeroProjeto}")]
        public IActionResult ListarPorProjeto(int numeroProjeto)
        {
            var projeto = projetoRepository.BuscarPorNumero(numeroProjeto);

            if (projeto == null)
            {
                return NotFound("Projeto não encontrado.");
            }

            var visitas = visitaRepository.ListarPorProjeto(numeroProjeto);

            return Ok(visitas);
        }
    }
}
