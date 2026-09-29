using Atividade1.Models;
using Atividade1.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : Controller
    {
        private readonly ICandidatoRepository candidatoRepository;

        public CandidatosController(ICandidatoRepository candidatoRepository)
        {
            this.candidatoRepository = candidatoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var candidatos = candidatoRepository.Listar();

            return Ok(candidatos);
        }

        [HttpPost]
        public IActionResult Adicionar(Candidato candidato)
        {
            var adicionado = candidatoRepository.Adicionar(candidato);

            if (!adicionado)
            {
                return Conflict("Já existe um candidato com esse número.");
            }

            return Created("", candidato);
        }
    }
}
