using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OldBooks.BLL.Models
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        public string Nascimento { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Livro> Livros  { get; set; }
        public virtual ICollection<ContaBancaria> ContasBancarias { get; set; }
        public virtual ICollection<Pedido> Pedidos  { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }
}
