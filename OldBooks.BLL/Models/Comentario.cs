using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBooks.BLL.Models
{
    public class Comentario
    {
        [Key]
        public int ComentarioId { get; set; }

        [ForeignKey("Livro")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        
        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        public string Texto { get; set; }

        public virtual ICollection<Resposta> Repostas { get; set; }
    }
}
