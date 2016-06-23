using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OldBooks.BLL.Models;

namespace OldBooks.DAL.Interfaces
{
    interface IEnderecoRepository
    {
        IEnumerable<Endereco> PegarTodosPorUsuario(string id);

        Endereco PegarPorId(int id);

        void Criar(Endereco endereco);

        void Atualizar(Endereco endereco);

        void Excluir(Endereco endereco);
    }
}
