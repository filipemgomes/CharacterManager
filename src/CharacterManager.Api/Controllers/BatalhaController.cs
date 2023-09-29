using AutoMapper;
using CharacterManager.Application.Interfaces;
using CharacterManager.Application.Models;
using CharacterManager.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CharacterManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : Controller
    {
        private readonly IBatalhaService _batalhaService;
        private readonly ILogBatalhaRepository _logBatalhaRepository;
        private readonly IMapper _mapper;

        public BatalhaController(IBatalhaService batalhaService, ILogBatalhaRepository logBatalhaRepository, IMapper mapper)
        {
            _batalhaService = batalhaService;
            _logBatalhaRepository = logBatalhaRepository;
            _mapper = mapper;
        }

        [HttpPost("iniciar")]
        public IActionResult IniciarBatalha(Guid personagem1Id, Guid personagem2Id)
        {
            //try
            //{
            _batalhaService.IniciarBatalha(personagem1Id, personagem2Id);

            var logs = _logBatalhaRepository.ObterLogBatalha(personagem1Id, personagem2Id);

            var logsModel = _mapper.Map<List<LogBatalhaModel>>(logs);

            return Ok(logsModel);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Erro ao iniciar a batalha: {ex.Message}");
            //}
        }

    }
}
