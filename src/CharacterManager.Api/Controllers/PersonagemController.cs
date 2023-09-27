using AutoMapper;
using CharacterManager.Api.RequestApi;
using CharacterManager.Application.Models;
using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Enums;
using CharacterManager.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CharacterManager.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : Controller
    {
        private readonly IPersonagemRepository _personagemRepository;
        private readonly IMapper _mapper;

        public PersonagemController(IPersonagemRepository personagemRepository, IMapper mapper)
        {
            _personagemRepository = personagemRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListaPersonagemModel>> GetAll()
        {
            var personagens = _personagemRepository.ObterTodos();
            return Ok(_mapper.Map<IEnumerable<ListaPersonagemModel>>(personagens));
        }

        [HttpGet("{id}")]
        public ActionResult<PersonagemModel> GetById(Guid id)
        {
            var personagem = _personagemRepository.ObterPorId(id);
            if (personagem == null)
                return NotFound();

            return Ok(_mapper.Map<PersonagemModel>(personagem));
        }

        [HttpPost]
        public ActionResult Create(string nome, string profissao)
        {
            var personagem = _mapper.Map<PersonagemModel>(_personagemRepository.Adicionar(nome, profissao));

            return CreatedAtAction(nameof(GetById), new { id = personagem.Id }, personagem);
        }
        
        [HttpGet("{id}/status")]
        public ActionResult<string> GetStatus(Guid id)
        {
            return Ok(_personagemRepository.ObterStatus(id));
        }

        [HttpGet("profissoes")]
        public IActionResult GetProfissoes()
        {
            var profissoes = Enum.GetValues(typeof(TipoProfissao))
                                  .Cast<TipoProfissao>()
                                  .Select(p => new
                                  {
                                      Id = (int)p,
                                      Nome = p.ToString()
                                  }).ToList();

            return Ok(profissoes);
        }

    }
}
