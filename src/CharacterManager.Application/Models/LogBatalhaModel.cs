namespace CharacterManager.Application.Models
{
    public class LogBatalhaModel
    {
        public Guid Id { get; set; }
        public Guid Personagem1Id { get; set; }
        public Guid Personagem2Id { get; set; }
        public string Mensagem { get; set; }
        public int Turno { get; set; }
        public DateTime DataHora { get; set; }
    }
}
