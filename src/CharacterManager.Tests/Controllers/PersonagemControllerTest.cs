using AutoMapper;
using CharacterManager.Api.Controllers;
using CharacterManager.Application.Models;
using CharacterManager.Application.Models.AutoMapper;
using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Interfaces.Repositories;
using CharacterManager.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using Xunit;

namespace CharacterManager.Tests.Controllers
{
    public class PersonagemControllerTest
    {
        private readonly Mock<IPersonagemRepository> _personagemRepositoryMock;
        private readonly IMapper _mapper;

        private readonly PersonagemController _controller;

        public PersonagemControllerTest()
        {
            _personagemRepositoryMock = new Mock<IPersonagemRepository>();
            _mapper = InitializeAutoMapper();
            _controller = new PersonagemController(_personagemRepositoryMock.Object, _mapper);
        }

        [Fact]
        public void DeveRetornarListaDePersonagens()
        {
            // Arrange
            var personagens = PersonagemMock.GerarListaPersonagemMock(2);
            
            _personagemRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(personagens);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<ListaPersonagemModel>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void DeveRetornarListaVaziaSeNaoHouverPersonagens()
        {
            // Arrange
            _personagemRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(new List<Personagem>());

            // Act
            _controller.GetAll();

            // Assert
            _personagemRepositoryMock.Verify(repo => repo.ObterTodos(), Times.Once);
        }


        [Fact]
        public void DeveRetornarPersonagemPorId()
        {
            // Arrange
            var personagem = PersonagemMock.GerarPersonagemMock();
            
            _personagemRepositoryMock.Setup(repo => repo.ObterPorId(It.IsAny<Guid>())).Returns(personagem);

            // Act
            var result = _controller.GetById(Guid.NewGuid());

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void DeveRetornarNotFoundSeIdNaoExistir()
        {
            // Arrange
            _personagemRepositoryMock.Setup(repo => repo.ObterPorId(It.IsAny<Guid>())).Returns((Personagem)null);

            // Act
            var result = _controller.GetById(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void DeveCriarNovoPersonagem()
        {
            // Arrange
            var personagem = PersonagemMock.GerarPersonagemMock();
            var personagemModel = new PersonagemModel();
            
            _personagemRepositoryMock.Setup(repo => repo.Adicionar(personagem.Nome, personagem.Profissao.ToString())).Returns(personagem);

            var urlHelperMock = new Mock<IUrlHelper>();
            urlHelperMock.Setup(x => x.Action(It.IsAny<UrlActionContext>())).Returns("http://localhost/api/Personagem/1");
            _controller.Url = urlHelperMock.Object;

            // Act
            var result = _controller.Create(personagem.Nome, personagem.Profissao.ToString());

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        public static IMapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
    }

}
