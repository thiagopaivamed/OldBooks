using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OldBooks.BLL.Models;
using OldBooks.DAL.Interfaces;

namespace OldBooks.DAL.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly OldBooksContext obc = new OldBooksContext();
        public IEnumerable<Categoria> PegarTodos()
        {
            var categorias = obc.Categorias.OrderBy(x => x.Nome).ToList();

            return categorias;
        }

        public Categoria PegarPorId(int id)
        {
            var categoria = obc.Categorias.FirstOrDefault(x => x.CategoriaId == id);

            return categoria;
        }

        public Categoria PegarPorNome(string Nome)
        {
            var categoria = obc.Categorias.FirstOrDefault(x => x.Nome == Nome);
            return categoria;
        }

        public void Criar(Categoria categoria)
        {
            if (categoria != null)
            {
                obc.Categorias.Add(categoria);
                obc.SaveChanges();
            }
        }

        public void Atualizar(Categoria categoria)
        {
            if (categoria != null)
            {
                obc.Categorias.Attach(categoria);
                obc.Entry(categoria).State = EntityState.Modified;
                obc.SaveChanges();
            }
        }

        public void Excluir(Categoria categoria)
        {
            var id = PegarPorId(categoria.CategoriaId);
            if (id != null)
            {
                obc.Categorias.Remove(categoria);
                obc.SaveChanges();
            }
        }
    }
}
