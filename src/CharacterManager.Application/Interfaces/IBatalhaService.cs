namespace CharacterManager.Application.Interfaces
{
    public interface IBatalhaService
    {
        void IniciarBatalha(Guid personagem1Id, Guid personagem2Id);
        void RealizarAtaque(Guid atacanteId, Guid defensorId);
        void FinalizarBatalha(Guid personagem1Id, Guid Personagem2Id, Guid vencedorId);
    }

}
