using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OldBooks.BLL.Models;
using OldBooks.DAL.Repositorios;

namespace OldBooks.Controllers
{
    public class MenuController : Controller
    {
        private LivroRepository _livroRepository = new LivroRepository();
        public MenuController() : this(new LivroRepository()) { }
        public MenuController(LivroRepository repository)
        {
            _livroRepository = repository;
        }

        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;
            IEnumerable<string> livros = _livroRepository.PegarTiposOrdenado();

            return PartialView(livros);
        }

    }
}
