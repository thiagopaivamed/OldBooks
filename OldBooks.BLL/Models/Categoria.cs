using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Remote("CategoriaDisponivel", "Categorias", ErrorMessage = "Categoria já cadastrada")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros  { get; set; }
    }
}
