using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OldBooks.BLL.Models;
using OldBooks.DAL.Interfaces;

namespace OldBooks.DAL.Repositorios
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly OldBooksContext obc = new OldBooksContext();
        public IEnumerable<Endereco> PegarTodosPorUsuario(string id)
        {
            var enderecos = obc.Enderecos.Where(x => x.UsuarioId == id).ToList();

            return enderecos;
        }

        public Endereco PegarPorId(int id)
        {
            var endereco = obc.Enderecos.FirstOrDefault(x => x.EnderecoId == id);

            return endereco;
        }

        public void Criar(Endereco endereco)
        {
            if (endereco != null)
            {
                obc.Enderecos.Add(endereco);
                obc.SaveChanges();
            }
        }

        public void Atualizar(Endereco endereco)
        {
            if (endereco != null)
            {
                obc.Enderecos.Attach(endereco);
                obc.Entry(endereco).State = EntityState.Modified;
                obc.SaveChanges();
            }
        }

        public void Excluir(Endereco endereco)
        {
            var id = PegarPorId(endereco.EnderecoId);

            if (id != null)
            {
                obc.Enderecos.Remove(endereco);
                obc.SaveChanges();
            }
        }
    }
}
