using System.Net;
using System.Web.Mvc;
using OldBooks.BLL.Models;
using OldBooks.DAL.Repositorios;

namespace OldBooks.Controllers
{
    public class FormaEntregasController : Controller
    {
        private FormaEntregaRepository _formaEntregaRepository = new FormaEntregaRepository();

        public FormaEntregasController() : this(new FormaEntregaRepository()) { }

        public FormaEntregasController(FormaEntregaRepository repository)
        {
            _formaEntregaRepository = repository;
        }
        
        // GET: FormaEntregas
        public ActionResult Index()
        {
            return View(_formaEntregaRepository.PegarTodos());
        }

        
        // GET: FormaEntregas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaEntregas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormaEntregaId,Descricao,Valor,Prazo,Estado")] FormaEntrega formaEntrega)
        {
            if (ModelState.IsValid)
            {
                _formaEntregaRepository.Criar(formaEntrega);
                return RedirectToAction("Index");
            }

            return View(formaEntrega);
        }

        // GET: FormaEntregas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id != null)
            {
                FormaEntrega formaEntrega = _formaEntregaRepository.PegarPorId(id);
                if (formaEntrega == null)
                {
                    return HttpNotFound();
                }
                return View(formaEntrega);
                
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
        }

        // POST: FormaEntregas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormaEntregaId,Descricao,Valor,Prazo,Estado")] FormaEntrega formaEntrega)
        {
            if (ModelState.IsValid)
            {
                _formaEntregaRepository.Atualizar(formaEntrega);
                return RedirectToAction("Index");
            }
            return View(formaEntrega);
        }
        

        // POST: FormaEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaEntrega formaEntrega = _formaEntregaRepository.PegarPorId(id);
            _formaEntregaRepository.Excluir(formaEntrega);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _formaEntregaRepository = null;
            }
            base.Dispose(disposing);
        }
    }
}
