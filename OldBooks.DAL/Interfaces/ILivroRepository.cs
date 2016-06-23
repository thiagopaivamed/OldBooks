using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OldBooks.BLL.Models;

namespace OldBooks.DAL.Interfaces
{
    interface ILivroRepository
    {
        IEnumerable<Livro> PegarTodos();
        IEnumerable<Livro> PegarPorCategoria(string categoria);

        IEnumerable<Livro> PegarPorTitulo(string titulo);

        IEnumerable<Livro> PegarPorTituloAutenticado(string titulo, string usuarioId);

        IEnumerable<Livro> PegarPorCategoriaAutenticado(string categoria, string usuarioId);
        IEnumerable<Livro> PegarTodosAutenticado(string usuarioId);

        IEnumerable<Livro> PegarTodosPorUsuario(string id);

        IEnumerable<string> PegarTiposOrdenado();

        Livro PegarPorId(int id);

        void Criar(Livro livro);

        void Atualizar(Livro livro);

        void Excluir(Livro livro);
    }
}
