using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OldBooks.BLL.Models;
using OldBooks.DAL.Repositorios;
using PagedList;

namespace OldBooks.Controllers
{
    [Authorize]
    public class LivrosController : Controller
    {
        private OldBooksContext db = new OldBooksContext();

         private LivroRepository _livroRepository = new LivroRepository();
         private ComentarioRepository _comentarioRepository = new ComentarioRepository();

         public LivrosController() : this(new LivroRepository() , new ComentarioRepository()) { }
         public LivrosController(LivroRepository repository, ComentarioRepository comentarioRepository)
        {
            _livroRepository = repository;
             _comentarioRepository = comentarioRepository;
        }


        // GET: Livros

        public ActionResult Index(int? pagina)
        {
            const int itensPorPagina = 16;
            int numeroPagina = pagina ?? 1;
            string id = User.Identity.GetUserId();
            return View(_livroRepository.PegarTodosPorUsuario(id).ToPagedList(numeroPagina, itensPorPagina));
        }

        // GET: Livros/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = _livroRepository.PegarPorId(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias.OrderBy(x => x.Nome), "CategoriaId", "Nome");
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroId,Titulo,Descricao,Foto,Autor,Paginas,Ano,Valor,Quantidade,CategoriaId,UsuarioId")] Livro livro)
        {
            livro.UsuarioId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
               
                //Pegar arquivo com nome arquivo
                HttpPostedFileBase photo = Request.Files["arquivo"];
                //Onde salvar
                string dirPath = Server.MapPath("~/Content/Images");

                if (photo != null)
                {
                    string urlImagem = string.Format("{0}/{1}", "/Content/Images", photo.FileName);
                    //Montar caminho da imagem
                    string filePath = string.Format("{0}/{1}", dirPath, photo.FileName);

                    photo.SaveAs(filePath);
                    livro.Foto = urlImagem;
                }

                _livroRepository.Criar(livro);
                TempData["confirmacao"] = "Livro " + livro.Titulo + " cadastrado com sucesso.";
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias.OrderBy(x => x.Nome), "CategoriaId", "Nome", livro.CategoriaId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = _livroRepository.PegarPorId(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias.OrderBy(x => x.Nome), "CategoriaId", "Nome", livro.CategoriaId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroId,Titulo,Descricao,Foto,Autor,Paginas,Ano,Valor,Quantidade,CategoriaId,UsuarioId")] Livro livro)
        {
            livro.UsuarioId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {

                //Pegar arquivo com nome arquivo
                HttpPostedFileBase photo = Request.Files["arquivo"];
                //Onde salvar
                string dirPath = Server.MapPath("~/Content/Images");

                if (photo != null)
                {
                    string urlImagem = string.Format("{0}/{1}", "/Content/Images", photo.FileName);
                    //Montar caminho da imagem
                    string filePath = string.Format("{0}/{1}", dirPath, photo.FileName);

                    photo.SaveAs(filePath);
                    livro.Foto = urlImagem;
                }

                _livroRepository.Atualizar(livro);
                TempData["atualizacao"] = "Livro " + livro.Titulo + " atualizado com sucesso.";
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias.OrderBy(x => x.Nome), "CategoriaId", "Nome", livro.CategoriaId);
            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var comentario = _comentarioRepository.PegarComentariosPorLivro(id);
            _comentarioRepository.ExcluirComentarios(comentario);
            Livro livro = _livroRepository.PegarPorId(id);
            _livroRepository.Excluir(livro);
            TempData["exclusao"] = "Livro " + livro.Titulo + " excluido com sucesso.";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
