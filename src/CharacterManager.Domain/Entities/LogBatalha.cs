namespace CharacterManager.Domain.Entities
{
    public class LogBatalha
    {
        public Guid Id { get; private set; }
        public Guid Personagem1Id { get; private set; }
        public Guid Personagem2Id { get; private set; }
        public string Mensagem { get; private set; }
        public int Turno { get; private set; } 
        public DateTime DataHora { get; private set; }

        public LogBatalha(Guid personagem1Id, Guid personagem2Id, string mensagem, int turno)
        {
            Id = Guid.NewGuid();
            Personagem1Id = personagem1Id;
            Personagem2Id = personagem2Id;
            Mensagem = mensagem;
            Turno = turno;
            DataHora = DateTime.Now;
        }
    }

}
