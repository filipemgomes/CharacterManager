using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Enums;

namespace CharacterManager.Domain.Interfaces.Repositories
{
    public interface IPersonagemRepository
    {
        Personagem Adicionar(string nome, string profissao);
        Personagem ObterPorId(Guid id);
        IEnumerable<Personagem> ObterTodos();
        void Atualizar(Personagem personagem);
        string ObterStatus(Guid id);
    }
}
