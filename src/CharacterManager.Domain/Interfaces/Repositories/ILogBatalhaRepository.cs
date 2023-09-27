using CharacterManager.Domain.Entities;

namespace CharacterManager.Domain.Repositories
{
    public interface ILogBatalhaRepository
    {
        void RegistrarInicioBatalha(Guid personagem1Id, Guid personagem2Id, Guid personagemInicianteId, int turno, string mensagem);
        void RegistrarAtaque(Guid personagemAtacanteId, Guid personagemDefensorId, int turno, string mensagem);
        void RegistrarVencedor(Guid personagem1Id, Guid personagem2Id, int turno, string mensagem);
        List<LogBatalha> ObterLogBatalha(Guid personagem1Id, Guid personagem2Id);
    }
}
