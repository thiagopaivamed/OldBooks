using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OldBooks.BLL.Models;

namespace OldBooks.Models
{
    public class Item
    {
        private Livro _livro = new Livro();
        public Livro Livro
        {
            get { return _livro; }
            set { _livro = value; }
        }

        private int quantidade;
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public Item() { }

        public Item(Livro Livro, int quantidade)
        {
            this.Livro = Livro;
            this.Quantidade = quantidade;
        }
    }
}