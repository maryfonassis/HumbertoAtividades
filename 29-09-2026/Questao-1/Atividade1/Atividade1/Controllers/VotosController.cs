using Atividade1.Models;
using Atividade1.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotosController : Controller
    {
        private readonly IVotoRepository votoRepository;
        private readonly ICandidatoRepository candidatoRepository;

        public VotosController(
            IVotoRepository votoRepository,
            ICandidatoRepository candidatoRepository)
        {
            this.votoRepository = votoRepository;
            this.candidatoRepository = candidatoRepository;
        }

        [HttpPost]
        public IActionResult Registrar(Voto voto)
        {
            var candidato = candidatoRepository.BuscarPorNumero(voto.NumeroCandidato);

            if (candidato == null)
            {
                return NotFound("Candidato não encontrado.");
            }

            voto.DataVoto = DateTime.Now;

            votoRepository.Adicionar(voto);

            return Created("", voto);
        }

        [HttpGet("{numeroCandidato}")]
        public IActionResult ListarPorCandidato(int numeroCandidato)
        {
            var candidato = candidatoRepository.BuscarPorNumero(numeroCandidato);

            if (candidato == null)
            {
                return NotFound("Candidato não encontrado.");
            }

            var votos = votoRepository.ListarPorCandidato(numeroCandidato);

            return Ok(votos);
        }
    }
}
