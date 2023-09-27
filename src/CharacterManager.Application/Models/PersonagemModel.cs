namespace CharacterManager.Application.Models
{
    public class PersonagemModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public int PontosDeVida { get; set; }
        public int Forca { get; set; }
        public int Destreza { get; set; }
        public int Inteligencia { get; set; }
        public int Ataque { get; set; }
        public int Velocidade { get; set; }
    }
}
