using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class FormaEntrega
    {
        public int FormaEntregaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Prazo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Estado { get; set; }

        public virtual ICollection<Pedido> Pedidos  { get; set; }
    }
}
