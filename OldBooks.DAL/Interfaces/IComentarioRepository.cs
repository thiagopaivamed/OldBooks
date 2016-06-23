using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OldBooks.BLL.Models;

namespace OldBooks.DAL.Interfaces
{
    interface IComentarioRepository
    {
        IEnumerable<Comentario> PegarComentariosPorLivro(int id);

        void Criar(Comentario comentario);

        void ExcluirComentarios(IEnumerable<Comentario> comentario);
    }
}
