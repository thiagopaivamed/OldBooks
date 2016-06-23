using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OldBooks.DAL.Repositorios;
using OldBooks.Models;

namespace OldBooks.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private LivroRepository _livroRepository = new LivroRepository();
        public CarrinhoController() : this(new LivroRepository()) { }
        public CarrinhoController(LivroRepository repository)
        {
            _livroRepository = repository;
        }

        public ActionResult AdicionaraoCarrinho(int id)
        {

            List<Item> carrinho;
            if (Session["carrinho"] == null)
            {
                carrinho = new List<Item>();
                carrinho.Add(new Item(_livroRepository.PegarPorId(id), 1));
                Session["carrinho"] = carrinho;
            }

            else
            {
                carrinho = (List<Item>)Session["carrinho"];
                int indice = LivroExiste(id);
                if (indice == -1)
                    carrinho.Add(new Item(_livroRepository.PegarPorId(id), 1));
                else
                    carrinho[indice].Quantidade = carrinho[indice].Quantidade + 1;
                Session["carrinho"] = carrinho;
            }

            return View("Carrinho");
        }

        public ActionResult Excluir(int id)
        {
            int indice = LivroExiste(id);
            List<Item> carrinho = (List<Item>)Session["carrinho"];

            if (carrinho[indice].Quantidade >= 2)
                carrinho[indice].Quantidade = carrinho[indice].Quantidade - 1;
            else
                carrinho.RemoveAt(indice);

            return View("Carrinho");
        }

        private int LivroExiste(int id)
        {
            List<Item> carrinho = (List<Item>)Session["carrinho"];
            for (int i = 0; i < carrinho.Count; i++)
            {
                if (carrinho[i].Livro.LivroId == id)
                    return i;
            }
            return -1;
        }

    }
}