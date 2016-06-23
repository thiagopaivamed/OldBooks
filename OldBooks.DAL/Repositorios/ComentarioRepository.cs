using System.Collections.Generic;
using System.Linq;
using OldBooks.BLL.Models;
using OldBooks.DAL.Interfaces;
using System.Data.Entity;

namespace OldBooks.DAL.Repositorios
{
    public class ComentarioRepository : IComentarioRepository
    {
        private OldBooksContext obc = new OldBooksContext();
        public IEnumerable<Comentario> PegarComentariosPorLivro(int id)
        {
            var comentarios = obc.Comentarios.Include(c => c.Livro).Include(c => c.Usuario).Where(x => x.LivroId == id);
            return comentarios;
        }

        public void Criar(Comentario comentario)
        {
            if (comentario != null)
            {
                obc.Comentarios.Add(comentario);
                obc.SaveChanges();
            }
        }

        public void ExcluirComentarios(IEnumerable<Comentario> comentario)
        {
            obc.Comentarios.RemoveRange(comentario);
            obc.SaveChanges();
        }
    }
}
