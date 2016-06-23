using System.Net;
using System.Web.Mvc;
using OldBooks.BLL.Models;
using OldBooks.DAL.Interfaces;
using OldBooks.DAL.Repositorios;
using PagedList;

namespace OldBooks.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaRepository _categoriaRepository = new CategoriaRepository();
        public CategoriasController() : this(new CategoriaRepository()) { }
        public CategoriasController(CategoriaRepository repository )
        {
            _categoriaRepository = repository;
        }

        // GET: Categorias
        public ActionResult Index(int? pagina)
        {
            const int itensPorPagina = 10;
            int numeroPagina = pagina ?? 1;
            return View(_categoriaRepository.PegarTodos().ToPagedList(numeroPagina, itensPorPagina));
        }
        
        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult CategoriaDisponivel(string Nome)
        {
            var categoria = _categoriaRepository.PegarPorNome(Nome);
            if (categoria == null)
                return Json(true, JsonRequestBehavior.AllowGet);

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaId,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Criar(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            if (id != null)
            {
                Categoria categoria = _categoriaRepository.PegarPorId(id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);

               
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Atualizar(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = _categoriaRepository.PegarPorId(id);
            _categoriaRepository.Excluir(categoria);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoriaRepository = null;
            }
            base.Dispose(disposing);
        }
    }
}
