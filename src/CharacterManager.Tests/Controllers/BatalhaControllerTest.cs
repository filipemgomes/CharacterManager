using AutoMapper;
using CharacterManager.Api.Controllers;
using CharacterManager.Application.Interfaces;
using CharacterManager.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CharacterManager.Tests.Controllers
{
    public class BatalhaControllerTest
    {
        private readonly Mock<IBatalhaService> _batalhaServiceMock;
        private readonly Mock<ILogBatalhaRepository> _logBatalhaRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BatalhaController _controller;

        public BatalhaControllerTest()
        {
            _batalhaServiceMock = new Mock<IBatalhaService>();
            _logBatalhaRepositoryMock = new Mock<ILogBatalhaRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new BatalhaController(_batalhaServiceMock.Object, _logBatalhaRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void DeveRetornarOkAoIniciarBatalhaComIdsValidos()
        {
            // Arrange
            Guid personagem1Id = Guid.NewGuid();
            Guid personagem2Id = Guid.NewGuid();

            // Act
            var result = _controller.IniciarBatalha(personagem1Id, personagem2Id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }







    }
}
