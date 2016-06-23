using System.Collections.Generic;
using OldBooks.BLL.Models;

namespace OldBooks.DAL.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> PegarTodos();
        Categoria PegarPorId(int id);
        Categoria PegarPorNome(string Nome);
        void Criar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Excluir(Categoria categoria);


    }
}
