using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBooks.BLL.Models
{
    public class Resposta
    {
        public int RespostaId { get; set; }

        public int ComentarioId { get; set; }
        public virtual Comentario Comentario { get; set; }

        public string Texto { get; set; }
    }
}
