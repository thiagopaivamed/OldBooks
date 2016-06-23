using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OldBooks.BLL.Models;
using OldBooks.DAL.Repositorios;
using OldBooks.Models;
using PagedList;

namespace OldBooks.Controllers
{
    public class HomeController : Controller
    {
        private LivroRepository _livroRepository = new LivroRepository();
        public HomeController() : this(new LivroRepository()) { }
        public HomeController(LivroRepository repository)
        {
            _livroRepository = repository;
        }

        
        public ActionResult Index(int? pagina)
        {
            string categoria = Request.QueryString["categoria"];
            string titulo = Request.QueryString["titulo"];

            const int itensPorPagina = 16;
            int numeroPagina = pagina ?? 1;

            if (User.Identity.IsAuthenticated)
            {
                var usuarioId = User.Identity.GetUserId();
                if (categoria != null) 
                {
                    return View(_livroRepository.PegarPorCategoriaAutenticado(categoria, usuarioId).ToPagedList(numeroPagina, itensPorPagina));
                }
                else if (titulo != null)
                {
                    return View(_livroRepository.PegarPorTituloAutenticado(titulo, usuarioId).ToPagedList(numeroPagina, itensPorPagina));
                } 
                else 
                {
                    return View(_livroRepository.PegarTodosAutenticado(usuarioId).ToPagedList(numeroPagina, itensPorPagina));
                }
            }

            if (categoria != null)
            {
                return View(_livroRepository.PegarPorCategoria(categoria).ToPagedList(numeroPagina, itensPorPagina));
            }
            else if (titulo != null)
            {
                return View(_livroRepository.PegarPorTitulo(titulo).ToPagedList(numeroPagina, itensPorPagina));
            }
            else
            {
                return View(_livroRepository.PegarTodos().ToPagedList(numeroPagina, itensPorPagina));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}