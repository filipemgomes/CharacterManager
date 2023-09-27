using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Domain.Entities
{
    public class Batalha
    {
        public Personagem Personagem1 { get; private set; }
        public Personagem Personagem2 { get; private set; }
        public List<LogBatalha> Logs { get; private set; } = new List<LogBatalha>();
        public Personagem Vencedor { get; private set; }
        public Personagem Perdedor { get; private set; }

        public Batalha(Personagem personagem1, Personagem personagem2)
        {
            Personagem1 = personagem1;
            Personagem2 = personagem2;
        }

        public void IniciarBatalha()
        {
            // Lógica para decidir a ordem dos ataques com base na velocidade
            // Lógica para realizar os ataques alternados
            // Lógica para registrar os logs
            // Lógica para determinar o vencedor e o perdedor
        }
    }

}
