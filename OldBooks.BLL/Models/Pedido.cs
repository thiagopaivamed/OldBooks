using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("FormaEntrega")]
        public int FormaEntregaId { get; set; }
        public virtual FormaEntrega FormaEntrega { get; set; }
        public double Valor { get; set; }
        public virtual ICollection<Pagamento> Pagamentos  { get; set; }


    }
}
