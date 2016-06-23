using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OldBooks.BLL.Models
{
    public class OldBooksContext : IdentityDbContext<Usuario>
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<ContaBancaria> ContaBancarias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<FormaEntrega> FormaEntregas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public OldBooksContext(): base("ConexaoDb", throwIfV1Schema: false) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
        public static OldBooksContext Create()
        {
            return new OldBooksContext();
        }
    }
}
