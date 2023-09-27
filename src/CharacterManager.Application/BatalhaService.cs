using CharacterManager.Application.Interfaces;
using CharacterManager.Domain.Interfaces.Repositories;
using CharacterManager.Domain.Repositories;

namespace CharacterManager.Application
{
    public class BatalhaService : IBatalhaService
    {
        private readonly IPersonagemRepository _personagemRepository;
        private readonly ILogBatalhaRepository _logBatalhaRepository;
        private int _turno = 1;
        private Random _random = new Random();

        public BatalhaService(IPersonagemRepository personagemRepository, ILogBatalhaRepository logBatalhaRepository)
        {
            _personagemRepository = personagemRepository;
            _logBatalhaRepository = logBatalhaRepository;
        }

        public void IniciarBatalha(Guid personagem1Id, Guid personagem2Id)
        {
            var personagem1 = _personagemRepository.ObterPorId(personagem1Id);
            var personagem2 = _personagemRepository.ObterPorId(personagem2Id);

            int velocidadeCalculadaPersonagem1, velocidadeCalculadaPersonagem2;

            do
            {
                velocidadeCalculadaPersonagem1 = _random.Next(0, personagem1.Velocidade + 1);
                velocidadeCalculadaPersonagem2 = _random.Next(0, personagem2.Velocidade + 1);
            } while (velocidadeCalculadaPersonagem1 == velocidadeCalculadaPersonagem2);

            var personagemIniciante = velocidadeCalculadaPersonagem1 > velocidadeCalculadaPersonagem2 ? personagem1 : personagem2;

            _logBatalhaRepository
                .RegistrarInicioBatalha(personagem1Id, 
                                        personagem2Id, 
                                        personagemIniciante.Id, 
                                        1,
                                        $"Turno 1: A batalha começou! {personagemIniciante.Nome} ataca primeiro!");

            // Lógica para realizar a luta completa
            while (personagem1.PontosDeVida > 0 && personagem2.PontosDeVida > 0)
            {
                RealizarAtaque(personagemIniciante.Id, personagemIniciante == personagem1 ? personagem2.Id : personagem1.Id);
                // Trocar a ordem dos personagens após cada ataque
                personagemIniciante = personagemIniciante == personagem1 ? personagem2 : personagem1;
            }


            var vencedor = personagem1.PontosDeVida > 0 ? personagem1 : personagem2;
            
            FinalizarBatalha(personagem1.Id, personagem2.Id, vencedor.Id);
        }

        public void RealizarAtaque(Guid atacanteId, Guid defensorId)
        {
            var atacante = _personagemRepository.ObterPorId(atacanteId);
            var defensor = _personagemRepository.ObterPorId(defensorId);

            // Lógica para calcular dano com base nos atributos da profissão
            int dano = _random.Next(0, atacante.Ataque + 1);

            if (dano < 0) dano = 0;

            defensor.ReduzirPontosDeVida(dano);
            _personagemRepository.Atualizar(defensor);

            _logBatalhaRepository
                .RegistrarAtaque(atacanteId, 
                                 defensorId,
                                 _turno
                                 , $"Turno {_turno}: {atacante.Nome} atacou {defensor.Nome} causando {dano} de dano. {defensor.Nome} tem {defensor.PontosDeVida} pontos de vida restantes.");
            _turno++;
        }

        public void FinalizarBatalha(Guid personagem1Id, Guid Personagem2Id, Guid vencedorId)
        {
            var vencedor = _personagemRepository.ObterPorId(vencedorId);
            _logBatalhaRepository
                .RegistrarVencedor(personagem1Id,
                                   Personagem2Id,
                                   _turno,
                                   $"Turno: {_turno}: {vencedor.Nome} venceu a batalha com {vencedor.PontosDeVida} pontos de vida restantes!");
        }
    }
}
