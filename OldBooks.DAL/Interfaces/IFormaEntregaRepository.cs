using System.Collections.Generic;
using OldBooks.BLL.Models;

namespace OldBooks.DAL.Interfaces
{
    interface IFormaEntregaRepository
    {
        IEnumerable<FormaEntrega> PegarTodos();
        FormaEntrega PegarPorId(int id);
        void Criar(FormaEntrega formaEntrega);
        void Atualizar(FormaEntrega formaEntrega);
        void Excluir(FormaEntrega formaEntrega);
    }
}
