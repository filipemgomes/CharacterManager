using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Repositories;
using CharacterManager.Infra.Contexts;

namespace CharacterManager.Infra.Repositories
{
    public class LogBatalhaRepository : ILogBatalhaRepository
    {
        private readonly AppDbContext _context;

        public LogBatalhaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void RegistrarInicioBatalha(Guid personagem1Id, Guid personagem2Id, Guid personagemInicianteId, int turno, string mensagem)
        {
            var log = new LogBatalha(personagem1Id, personagem2Id, mensagem, turno);
            _context.LogsBatalha.Add(log);
            _context.SaveChanges();
        }


        public void RegistrarAtaque(Guid personagemAtacanteId, Guid personagemDefensorId, int turno, string mensagem)
        {
            var log = new LogBatalha(personagemAtacanteId, personagemDefensorId, mensagem, turno);
            _context.LogsBatalha.Add(log);
            _context.SaveChanges();
        }


        public void RegistrarVencedor(Guid personagem1Id, Guid personagem2Id, int turno, string mensagem)
        {
            var log = new LogBatalha(personagem1Id, personagem2Id, mensagem, turno);
            _context.LogsBatalha.Add(log);
            _context.SaveChanges();
        }


        public List<LogBatalha> ObterLogBatalha(Guid personagem1Id, Guid personagem2Id)
        {
            return _context.LogsBatalha
                .Where(log => (log.Personagem1Id == personagem1Id && log.Personagem2Id == personagem2Id) ||
                              (log.Personagem1Id == personagem2Id && log.Personagem2Id == personagem1Id))
                .OrderBy(log => log.DataHora)
                .ToList();
        }
    }
}

