using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OldBooks.BLL.Models;
using OldBooks.DAL.Interfaces;

namespace OldBooks.DAL.Repositorios
{
    public class FormaEntregaRepository : IFormaEntregaRepository
    {
        private readonly OldBooksContext obc = new OldBooksContext();
        public IEnumerable<FormaEntrega> PegarTodos()
        {
            var formas = obc.FormaEntregas.ToList();

            return formas;
        }

        public FormaEntrega PegarPorId(int id)
        {
            var forma = obc.FormaEntregas.FirstOrDefault(x => x.FormaEntregaId == id);

            return forma;
        }

        public void Criar(FormaEntrega formaEntrega)
        {
            if (formaEntrega != null)
            {
                obc.FormaEntregas.Add(formaEntrega);
                obc.SaveChanges();
            }
        }

        public void Atualizar(FormaEntrega formaEntrega)
        {
            if (formaEntrega != null)
            {
                obc.FormaEntregas.Attach(formaEntrega);
                obc.Entry(formaEntrega).State = EntityState.Modified;
                obc.SaveChanges();
            }
        }

        public void Excluir(FormaEntrega formaEntrega)
        {
            var id = PegarPorId(formaEntrega.FormaEntregaId);

            if (id != null)
            {
                obc.FormaEntregas.Remove(formaEntrega);
                obc.SaveChanges();
            }
        }
    }
}
