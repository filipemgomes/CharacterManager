using Bogus;
using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Enums;

namespace CharacterManager.Tests.Mocks
{
    public static class PersonagemMock
    {
        public static Personagem GerarPersonagemMock()
        {
            var faker = new Faker<Personagem>("pt_BR")
                .CustomInstantiator(f =>
                {
                    var nome = f.Person.FirstName;
                    var profissao = f.PickRandom<TipoProfissao>().ToString();

                    return new Personagem(nome, profissao);
                });

            return faker.Generate();
        }
    }
}
