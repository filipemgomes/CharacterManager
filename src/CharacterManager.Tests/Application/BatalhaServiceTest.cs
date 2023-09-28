using CharacterManager.Application;
using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Exceptions;
using CharacterManager.Domain.Interfaces.Repositories;
using CharacterManager.Domain.Repositories;
using CharacterManager.Tests.Mocks;
using Moq;
using Xunit;

namespace CharacterManager.Tests.Application
{
    public class BatalhaServiceTest
    {
        private readonly BatalhaService _batalhaService;
        private readonly Mock<IPersonagemRepository> _personagemRepositoryMock;
        private readonly Mock<ILogBatalhaRepository> _logBatalhaRepositoryMock;

        public BatalhaServiceTest()
        {
            _personagemRepositoryMock = new Mock<IPersonagemRepository>();
            _logBatalhaRepositoryMock = new Mock<ILogBatalhaRepository>();
            _batalhaService = new BatalhaService(_personagemRepositoryMock.Object, _logBatalhaRepositoryMock.Object);
        }

        [Fact]
        public void IniciarBatalha_DeveComecarComPersonagemDeMaiorVelocidade()
        {
            // Arrange
            var personagem1 = PersonagemMock.GerarPersonagemMock();
            var personagem2 = PersonagemMock.GerarPersonagemMock();

            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(personagem1.Id)).Returns(personagem1);
            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(personagem2.Id)).Returns(personagem2);

            // Act
            _batalhaService.IniciarBatalha(personagem1.Id, personagem2.Id);

            // Assert
            _logBatalhaRepositoryMock.Verify(lbr => lbr.RegistrarInicioBatalha(It.IsAny<Guid>(), It.IsAny<Guid>(), personagem1.Id, 1, It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void RealizarAtaque_DanoCalculado_DeveReduzirPontosDeVidaDoDefensor()
        {
            // Arrange
            var atacante = PersonagemMock.GerarPersonagemMock();
            var defensor = PersonagemMock.GerarPersonagemMock();
            var pontosDeVidaInicial = defensor.PontosDeVida;

            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(atacante.Id)).Returns(atacante);
            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(defensor.Id)).Returns(defensor);

            // Act
            _batalhaService.RealizarAtaque(atacante.Id, defensor.Id);

            // Assert
            Assert.True(defensor.PontosDeVida < pontosDeVidaInicial);
        }

        [Fact]
        public void FinalizarBatalha_PersonagemComPontosDeVida_DeveSerVencedor()
        {
            // Arrange
            var personagem1 = PersonagemMock.GerarPersonagemMock();
            var personagem2 = PersonagemMock.GerarPersonagemMock();

            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(personagem1.Id)).Returns(personagem1);
            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(personagem2.Id)).Returns(personagem2);

            // Act
            _batalhaService.IniciarBatalha(personagem1.Id, personagem2.Id);

            // Assert
            _logBatalhaRepositoryMock.Verify(l => l.RegistrarVencedor(personagem1.Id, personagem2.Id,  It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void IniciarBatalha_PersonagemNaoEncontrado_DeveLancarExcecao()
        {
            // Arrange
            var personagem1Id = Guid.NewGuid();
            var personagem2Id = Guid.NewGuid();

            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(It.IsAny<Guid>())).Returns((Personagem)null);

            // Act & Assert
            Assert.Throws<DomainException>(() => _batalhaService.IniciarBatalha(personagem1Id, personagem2Id));
        }

        [Fact]
        public void IniciarBatalha_DeveRegistrarLogsDeBatalha()
        {
            // Arrange
            var personagem1 = PersonagemMock.GerarPersonagemMock();
            var personagem2 = PersonagemMock.GerarPersonagemMock();

            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(personagem1.Id)).Returns(personagem1);
            _personagemRepositoryMock.Setup(pr => pr.ObterPorId(personagem2.Id)).Returns(personagem2);

            // Act
            _batalhaService.IniciarBatalha(personagem1.Id, personagem2.Id);

            // Assert
            _logBatalhaRepositoryMock.Verify(l => l.RegistrarInicioBatalha(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            _logBatalhaRepositoryMock.Verify(l => l.RegistrarAtaque(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<string>()), Times.AtLeastOnce);
            _logBatalhaRepositoryMock.Verify(l => l.RegistrarVencedor(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }



    }
}
