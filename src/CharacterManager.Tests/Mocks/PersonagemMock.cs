using Bogus;
using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Enums;

namespace CharacterManager.Tests.Mocks
{
    public static class PersonagemMock
    {
        private static Faker<Personagem> CreateFaker()
        {
            return new Faker<Personagem>("pt_BR")
                .CustomInstantiator(f =>
                {
                    var nome = f.Random.String2(f.Random.Number(1, 15), "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_");
                    var profissao = f.PickRandom<TipoProfissao>().ToString();

                    return new Personagem(nome, profissao);
                });
        }

        public static Personagem GerarPersonagemMock()
        {
            return CreateFaker().Generate();
        }

        public static List<Personagem> GerarListaPersonagemMock(int quantidade)
        {
            return CreateFaker().Generate(quantidade);
        }
    }
}
