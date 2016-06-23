using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int Prazo { get; set; }

        public int ValidadeBoleto { get; set; }

        public string StatusCompra { get; set; }
    }
}
