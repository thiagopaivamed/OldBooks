using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Número Inválido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; }
    }
}
