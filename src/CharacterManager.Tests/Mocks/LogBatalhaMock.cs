using Bogus;
using CharacterManager.Domain.Entities;

namespace CharacterManager.Tests.Mocks
{
    public static class LogBatalhaMock
    {
        private static Faker<LogBatalha> BaseFaker(Guid personagem1Id, Guid personagem2Id, string mensagem, int turno)
        {
            return new Faker<LogBatalha>()
                .CustomInstantiator(f =>
                {
                    return new LogBatalha(personagem1Id, personagem2Id, mensagem, turno);
                });
        }

        public static LogBatalha GerarLogInicioBatalha(Guid personagem1Id, Guid personagem2Id, Guid inicianteId, int turno)
        {
            string mensagem = $"Turno {turno}: A batalha começou! Personagem {inicianteId} ataca primeiro!";
            var log = BaseFaker(personagem1Id, personagem2Id, mensagem, turno).Generate();
            
            return log;
        }

        public static LogBatalha GerarLogAtaque(Guid atacanteId, Guid defensorId, int dano, int pontosDeVidaRestantes, int turno)
        {
            string mensagem = $"Turno {turno}: Personagem {atacanteId} atacou Personagem {defensorId} causando {dano} de dano. Personagem {defensorId} tem {pontosDeVidaRestantes} pontos de vida restantes.";
            var log = BaseFaker(atacanteId, defensorId, mensagem, turno).Generate();

            return log;
        }

        public static LogBatalha GerarLogVencedor(Guid personagem1Id, Guid personagem2Id, Guid vencedorId, int pontosDeVidaRestantes, int turno)
        {
            string mensagem = $"Turno {turno}: Personagem {vencedorId} venceu a batalha com {pontosDeVidaRestantes} pontos de vida restantes!";
            var log = BaseFaker(personagem1Id, personagem2Id, mensagem, turno).Generate();
            
            return log;
        }
    }

}
