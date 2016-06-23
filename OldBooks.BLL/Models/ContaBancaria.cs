using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class ContaBancaria
    {
        [Key]
        public int ContaBancariaId { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Conta { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string TitularConta { get; set; }
    }
}
