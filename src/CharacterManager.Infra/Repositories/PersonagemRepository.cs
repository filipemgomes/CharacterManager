using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Enums;
using CharacterManager.Domain.Interfaces.Repositories;
using CharacterManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Infra.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly AppDbContext _context;

        public PersonagemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Personagem Adicionar(string nome, string profissao)
        {
            var personagem = new Personagem(nome, profissao);

            _context.Add(personagem);
            _context.SaveChanges();

            return personagem;
        }

        public Personagem ObterPorId(Guid id)
        {
            return _context.Personagens.Find(id);
        }

        public IEnumerable<Personagem> ObterTodos()
        {
            return _context.Personagens.ToList();
        }

        public void Atualizar(Personagem personagem)
        {
            _context.Update(personagem);
            _context.SaveChanges();
        }

        public string ObterStatus(Guid id)
        {
            var personagem = ObterPorId(id);
            return personagem.PontosDeVida > 0 ? "Vivo" : "Morto";
        }
    }

}
