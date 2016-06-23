using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        //[Required(ErrorMessage = "Campo Obrigatório")]
        public string Foto { get; set; }
       
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Autor { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Número Inválido")]
        public int Paginas { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0, 2015, ErrorMessage = "Número Inválido")]
        public int Ano { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Número Inválido")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Número Inválido")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        
        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
