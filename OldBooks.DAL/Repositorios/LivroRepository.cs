using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OldBooks.BLL.Models;
using OldBooks.DAL.Interfaces;

namespace OldBooks.DAL.Repositorios
{
    public class LivroRepository : ILivroRepository
    {
        private readonly OldBooksContext obc = new OldBooksContext();
        public IEnumerable<Livro> PegarTodos()
        {
            var livros = obc.Livros.Include(l => l.Categoria).Include(l => l.Usuario).ToList();

            return livros;
        }

        public IEnumerable<Livro> PegarPorCategoria(string categoria)
        {
            var livros = obc.Livros.Include(p => p.Usuario).Include(x => x.Categoria).AsParallel().Where(p => p.Categoria.Nome == categoria).OrderBy(p => p.LivroId);
            return livros;
        }

        public IEnumerable<Livro> PegarPorCategoriaAutenticado(string categoria, string usuarioId)
        {
            var livros = obc.Livros.Include(p => p.Usuario).Include(x => x.Categoria).AsParallel().Where(p => p.Categoria.Nome == categoria && p.UsuarioId != usuarioId).OrderBy(p => p.LivroId);
            return livros;
        }

        public IEnumerable<Livro> PegarPorTitulo(string titulo)
        {
            var livros = obc.Livros.Include(p => p.Usuario).Include(x => x.Categoria).AsParallel().Where(p => p.Titulo.Contains(titulo)).OrderBy(p => p.LivroId);
            return livros;
        }

        public IEnumerable<Livro> PegarPorTituloAutenticado(string titulo, string usuarioId)
        {
            var livros = obc.Livros.Include(p => p.Usuario).Include(x => x.Categoria).AsParallel().Where(p => p.Titulo.Contains(titulo) && p.UsuarioId != usuarioId).OrderBy(p => p.LivroId);
            return livros;
        }


        public IEnumerable<Livro> PegarTodosAutenticado(string usuarioId)
        {
            const int tamPagina = 6;
            var livros = obc.Livros.Include(p => p.Usuario).Include(x => x.Categoria).AsParallel().Where(p => p.UsuarioId != usuarioId).OrderBy(p => p.LivroId);

            return livros;
        }

        public IEnumerable<Livro> PegarTodosPorUsuario(string id)
        {
            
            var livros = obc.Livros.Include(l => l.Categoria).Include(l => l.Usuario).Where(x => x.UsuarioId == id).ToList();

            return livros;
        }

        public IEnumerable<string> PegarTiposOrdenado()
        {
            IEnumerable<string> categorias = obc.Categorias.Select(x => x.Nome).Distinct().OrderBy(x => x);

            return categorias;
        }//

        public Livro PegarPorId(int id)
        {
            var livro = obc.Livros.Include(l => l.Categoria).Include(l => l.Usuario).FirstOrDefault(x => x.LivroId == id);

            return livro;
        }

        public void Criar(Livro livro)
        {
            if (livro != null)
            {
                obc.Livros.Add(livro);
                obc.SaveChanges();
            }
        }

        public void Atualizar(Livro livro)
        {
            if (livro != null)
            {
                obc.Livros.Attach(livro);
                obc.Entry(livro).State = EntityState.Modified;
                obc.SaveChanges();
            }
        }

        public void Excluir(Livro livro)
        {
            var l = PegarPorId(livro.LivroId);
            if (l != null)
            {
                obc.Livros.Remove(l);
                obc.SaveChanges();
            }
        }
    }
}
