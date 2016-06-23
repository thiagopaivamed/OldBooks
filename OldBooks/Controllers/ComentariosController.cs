using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OldBooks.BLL.Models;
using OldBooks.DAL.Repositorios;
using PagedList;

namespace OldBooks.Controllers
{
    public class ComentariosController : Controller
    {

        private ComentarioRepository _comentarioRepository = new ComentarioRepository();
        public ComentariosController() : this(new ComentarioRepository()) { }
        public ComentariosController(ComentarioRepository repository)
        {
            _comentarioRepository = repository;
        }

        public async Task<ActionResult> Index(int id)
        {
            return View(_comentarioRepository.PegarComentariosPorLivro(id));
        }

        // GET: Comentarios/Create
        public ActionResult Create(int id)
        {
            var comentarios = new Comentario();
            comentarios.LivroId = id;
            return View(comentarios);
        }

        // POST: Comentarios/Create
        
        [HttpPost]
        [ChildActionOnly]
        public ActionResult Create([Bind(Include = "ComentarioId,LivroId,UsuarioId,Texto")] Comentario comentario, int id)
        {
            
            comentario.UsuarioId = User.Identity.GetUserId();
            comentario.LivroId = id;

            if (ModelState.IsValid && !string.IsNullOrEmpty(comentario.Texto))
            {
                _comentarioRepository.Criar(comentario);
                ModelState.Clear();
                return PartialView("Create");
            }
            return PartialView(comentario);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _comentarioRepository = null;
            }
            base.Dispose(disposing);
        }
    }
}
