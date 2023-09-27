using CharacterManager.Domain.Enums;
using CharacterManager.Domain.Exceptions;
using FluentValidation;

namespace CharacterManager.Domain.Entities
{
    public class Personagem
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public TipoProfissao Profissao { get; private set; }
        public int PontosDeVida { get; private set; }
        public int Forca { get; private set; }
        public int Destreza { get; private set; }
        public int Inteligencia { get; private set; }
        public int Ataque => CalculeAtaque();
        public int Velocidade => CalculeVelocidade();

        public Personagem()
        {
                
        }

        public Personagem(string nome, string profissao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Profissao = (TipoProfissao)Enum.Parse(typeof(TipoProfissao), profissao, true);

            InicializarAtributosProfissao();
            Validate();
        }

        private void InicializarAtributosProfissao()
        {
            switch (Profissao)
            {
                case TipoProfissao.Warrior:
                    PontosDeVida = 20;
                    Forca = 10;
                    Destreza = 5;
                    Inteligencia = 5; ;
                    break;
                case TipoProfissao.Thief:
                    PontosDeVida = 15;
                    Forca = 4;
                    Destreza = 10;
                    Inteligencia = 4; ;
                    break;
                case TipoProfissao.Mage:
                    PontosDeVida = 12;
                    Forca = 5;
                    Destreza = 6;
                    Inteligencia = 10; ;
                    break;
                default:
                    break;
            }
        }

        public void ReduzirPontosDeVida(int dano)
            => PontosDeVida -= dano;

        private int CalculeAtaque()
        {
            switch (Profissao)
            {
                case TipoProfissao.Warrior:
                    return (int)(0.8 * Forca + 0.2 * Destreza);
                case TipoProfissao.Thief:
                    return (int)(0.25 * Forca + Destreza + 0.25 * Inteligencia);
                case TipoProfissao.Mage:
                    return (int)(0.2 * Forca + 0.5 * Destreza + 1.5 * Inteligencia);
                default:
                    throw new DomainException("Profissão inválida");
            }
        }

        private int CalculeVelocidade()
        {
            switch (Profissao)
            {
                case TipoProfissao.Warrior:
                    return (int)(0.6 * Destreza + 0.2 * Inteligencia);
                case TipoProfissao.Thief:
                    return (int)(0.8 * Destreza);
                case TipoProfissao.Mage:
                    return (int)(0.2 * Forca + 0.5 * Destreza);
                default:
                    throw new DomainException("Profissão inválida");
            }
        }

        private void Validate()
        {
            var validator = new InlineValidator<Personagem>();

            validator.RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(15).WithMessage("Nome não pode ter mais de 15 caracteres.")
                .Matches("^[a-zA-Z_]+$").WithMessage("Nome deve conter apenas letras.");

            var validationResult = validator.Validate(this);
            if (!validationResult.IsValid)
            {
                throw new DomainException(string.Join(", ", validationResult.Errors));
            }
        }
    }
}
